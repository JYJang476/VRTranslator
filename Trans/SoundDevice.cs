using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.CoreAudioApi;
using HardwareHelperLib;
using Microsoft.Win32.SafeHandles;
namespace Trans
{
    class SoundDevice
    {
        public float GetMaskPeekValue(int deviceindex)
        {
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDeviceCollection EnumDevice = devEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            MMDevice dd = devEnum.GetDevice(EnumDevice[deviceindex].ID);
            float lvl = dd.AudioMeterInformation.MasterPeakValue;

            return lvl;
        }
        public void SetDeviceEnable(string devname, bool devbool)
        {

            HH_Lib hwh = new HH_Lib();

            hwh.SetDeviceState(new string[] { devname , null } , devbool);

            
        }
        public List<MMDevice> GetInputDeviceList()
        {
            //List<MMDeviceCollection> DeviceList = new List<MMDeviceCollection>;

            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDeviceCollection EnumDevice = devEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active | DeviceState.Disabled);
            //DeviceList = EnumDevice.ToList();

            return EnumDevice.ToList();
        }
    }
}
