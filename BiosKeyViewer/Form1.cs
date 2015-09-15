using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management.Instrumentation;
using System.Collections;
using System.Management;
using Microsoft.Win32;


namespace BiosKeyViewer
{
    public partial class Form1 : Form
    {
        public static string signature2 { get; set; }
        public static string length2 { get; set; }
        public static string revision2 { get; set; }
        public static string checksum2 { get; set; }
        public static string oemid2 { get; set; }
        public static string oemtableid2 { get; set; }
        public static string oemrev2 { get; set; }
        public static string creatorid2 { get; set; }
        public static string creatorrev2 { get; set; }
        public static string sls_version2 { get; set; }
        public static string sls_reserved2 { get; set; }
        public static string sls_datatype2 { get; set; }
        public static string sls_datareserved2 { get; set; }
        public static string sls_datalength2 { get; set; }
        public static string sls_data2 { get; set; }
        public static string WindowsKey { get; set; }

        #region Kernel 32 Import
        [DllImport("kernel32")]
        private static extern uint EnumSystemFirmwareTables(uint FirmwareTableProviderSignature, IntPtr pFirmwareTableBuffer, uint BufferSize);
        [DllImport("kernel32")]
        private static extern uint GetSystemFirmwareTable(uint FirmwareTableProviderSignature, uint FirmwareTableID, IntPtr pFirmwareTableBuffer, uint BufferSize);

        private static bool checkMSDM(out byte[] buffer)
        {
            uint firmwareTableProviderSignature = 0x41435049; // 'ACPI' in Hexadecimal
            uint bufferSize = EnumSystemFirmwareTables(firmwareTableProviderSignature, IntPtr.Zero, 0);
            IntPtr pFirmwareTableBuffer = Marshal.AllocHGlobal((int)bufferSize);
            buffer = new byte[bufferSize];
            EnumSystemFirmwareTables(firmwareTableProviderSignature, pFirmwareTableBuffer, bufferSize);
            Marshal.Copy(pFirmwareTableBuffer, buffer, 0, buffer.Length);
            Marshal.FreeHGlobal(pFirmwareTableBuffer);
            if (Encoding.ASCII.GetString(buffer).Contains("MSDM"))
            {
                uint firmwareTableID = 0x4d44534d; // Reversed 'MSDM' in Hexadecimal
                bufferSize = GetSystemFirmwareTable(firmwareTableProviderSignature, firmwareTableID, IntPtr.Zero, 0);
                buffer = new byte[bufferSize];
                pFirmwareTableBuffer = Marshal.AllocHGlobal((int)bufferSize);
                GetSystemFirmwareTable(firmwareTableProviderSignature, firmwareTableID, pFirmwareTableBuffer, bufferSize);
                Marshal.Copy(pFirmwareTableBuffer, buffer, 0, buffer.Length);
                Marshal.FreeHGlobal(pFirmwareTableBuffer);
                return true;
            }
            return false;

        }
        #endregion

        #region Get Bios Data
        private void getKey()
        {
            byte[] buffer = null;
            if (checkMSDM(out buffer))
            {
                Encoding encoding = Encoding.GetEncoding(0x4e4);
                string signature = encoding.GetString(buffer, 0x0, 0x4);
                int length = BitConverter.ToInt32(buffer, 0x4);
                byte revision = (byte)buffer.GetValue(0x8);
                byte checksum = (Byte)buffer.GetValue(0x9);
                string oemid = encoding.GetString(buffer, 0xa, 0x6);
                string oemtableid = encoding.GetString(buffer, 0x10, 0x8);
                int oemrev = BitConverter.ToInt32(buffer, 0x18);
                string creatorid = encoding.GetString(buffer, 0x1c, 0x4);
                int creatorrev = BitConverter.ToInt32(buffer, 0x20);
                int sls_version = BitConverter.ToInt32(buffer, 0x24);
                int sls_reserved = BitConverter.ToInt32(buffer, 0x28);
                int sls_datatype = BitConverter.ToInt32(buffer, 0x2C);
                int sls_datareserved = BitConverter.ToInt32(buffer, 0x30);
                int sls_datalength = BitConverter.ToInt32(buffer, 0x34);
                string sls_data = encoding.GetString(buffer, 0x38, sls_datalength);

                signature2 = signature;                             //Signature
                length2 = length.ToString();                        //Length
                revision2 = revision.ToString();                    //Revison
                checksum2 = checksum.ToString();                    //Checksum
                oemid2 = oemid.ToString();                          //OEM ID
                oemtableid2 = oemtableid.ToString();                //OEM Table ID 
                oemrev2 = oemrev.ToString();                        //OEM Revision
                creatorid2 = creatorid.ToString();                  //Creator ID
                creatorrev2 = creatorrev.ToString();                //Crator Revision
                sls_version2 = sls_version.ToString();              //SLS Version
                sls_reserved2 = sls_reserved.ToString();            //SLS Reserved
                sls_datatype2 = sls_datatype.ToString();            //SLS Datatype
                sls_datareserved2 = sls_datareserved.ToString();    //SLS Data Reserved
                sls_datalength2 = sls_datalength.ToString();        //SLS Data Length
                sls_data2 = sls_data.ToString();                    //Key
            }
            else
            {
                sls_data2 = "MSDM Table Not Found!";
            }
        }
        #endregion

        #region Get Windows Key from WINDOWS
        public static string GetPartialPkey()
        {
            ManagementObject mObj = new ManagementObjectSearcher("root\\CIMV2", "SELECT PartialProductKey, LicenseStatus FROM SoftwareLicensingProduct WHERE PartialProductKey <> null AND LicenseStatus = 1").Get().OfType<ManagementObject>().First();
            {
                return Convert.ToString(mObj["PartialProductKey"]);
            }
        }

       
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getKey();
            if (sls_data2 != "MSDM Table Not Found!")
            {
                string result = 
                    "Signature         : " + signature2 +
                    "\r\nLength            : " + length2 +
                    "\r\nRevison           : " + revision2 +
                    "\r\nChecksum          : " + checksum2 +
                    "\r\nOEM ID            : " + oemid2 +
                    "\r\nOEM Table ID      : " + oemtableid2 +
                    "\r\nOEM Revision      : " + oemrev2 +
                    "\r\nCreator ID        : " + creatorid2 +
                    "\r\nCreator Revision  : " + creatorrev2 +
                    "\r\nSLS Version       : " + sls_version2 +
                    "\r\nSLS Reserved      : " + sls_reserved2 +
                    "\r\nSLS Datatype      : " + sls_datatype2 +
                    "\r\nSLS Data Reserved : " + sls_datareserved2 +
                    "\r\nSLS Data Length   : " + sls_datalength2 +
                    "\r\nKey               : " + sls_data2;
                textBox_content.Text = result;
                textBox_injectedkey.Text = sls_data2;
                try
                {
                    textBox_winkey.Text = GetPartialPkey();
                }
                catch { textBox_winkey.Text = "Windows Key Not Found!"; }

            }
            else
            {
                textBox_content.Text = "MSDM Table Not Found!";
                textBox_injectedkey.Text = "No Injected Windows Key found!";
            }
        }

        private void label_credits_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.github.com/romelsan");
        }
    }
}
