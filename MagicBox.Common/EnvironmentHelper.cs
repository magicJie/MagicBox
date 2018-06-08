using Microsoft.Win32;
using System;
using System.Management;
using System.Net.NetworkInformation;

namespace MagicBox
{
    /// <summary>
    /// 扩展一些当前运行环境处理的方法
    /// <see cref="System.Environment"/>
    /// </summary>
    public class EnvironmentHelper
    {
        /// <summary>
        /// 获取当前设备特征信息
        /// </summary>
        /// <returns></returns>
        public static string GetMachineInfo()
        {
            var info = string.Empty;
            var cpu = GetCPUInfo();
            var baseBoard = GetBaseBoardInfo();
            var bios = GetBIOSInfo();
            var mac = GetMACInfo();
            info = string.Concat(cpu, baseBoard, bios, mac);
            return info;
        }

        private static object GetMACInfo()
        {
            string key = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\";
            string macAddress = string.Empty;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                    && adapter.GetPhysicalAddress().ToString().Length != 0)
                {
                    string fRegistryKey = key + adapter.Id + "\\Connection";
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                    if (rk != null)
                    {
                        string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                        int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                        if (fPnpInstanceID.Length > 3 &&
                            fPnpInstanceID.Substring(0, 3) == "PCI")
                        {
                            macAddress = adapter.GetPhysicalAddress().ToString();
                            for (int i = 1; i < 6; i++)
                            {
                                macAddress = macAddress.Insert(3 * i - 1, ":");
                            }
                            break;
                        }
                    }

                }
            }
            return macAddress;
        }

        private static object GetBIOSInfo()
        {
            return GetHardWareInfo("Win32_BIOS", "SerialNumber");
        }

        private static object GetBaseBoardInfo()
        {
            return GetHardWareInfo("Win32_BaseBoard", "SerialNumber");
        }

        private static object GetCPUInfo()
        {
            return GetHardWareInfo("Win32_Processor", "ProcessorId");
        }
        private static object GetHardWareInfo(string typePath, string key)
        {
            var managementClass = new ManagementClass(typePath);
            var mn = managementClass.GetInstances();
            var properties = managementClass.Properties;
            foreach (PropertyData property in properties)
            {
                if (property.Name == key)
                {
                    foreach (ManagementObject m in mn)
                    {
                        return m.Properties[property.Name].Value.ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
