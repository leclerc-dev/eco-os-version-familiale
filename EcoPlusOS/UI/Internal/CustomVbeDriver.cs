using System;
using Cosmos.Core;
using Cosmos.Core.IOGroup;

namespace EcoPlusOS.UI.Internal
{
#if VBE
    public class CustomVbeDriver
    {

        private readonly VBE _io = Global.BaseIOGroups.VBE;

        private enum RegisterIndex
        {
            DisplayId = 0x00,
            DisplayXResolution,
            DisplayYResolution,
            DisplayBpp,
            DisplayEnable,
            DisplayBankMode,
            DisplayVirtualWidth,
            DisplayVirtualHeight,
            DisplayXOffset,
            DisplayYOffset
        };

        [Flags]
        private enum EnableValues
        {
            Disabled = 0x00,
            Enabled,
            UseLinearFrameBuffer = 0x40,
            NoClearMemory = 0x80,
        };

        public CustomVbeDriver(ushort xres, ushort yres, ushort bpp)
        {
            Global.mDebugger.SendInternal($"Creating VBEDriver with Mode {xres}*{yres}@{bpp}");
            VbeSet(xres, yres, bpp);
        }

        private void Write(RegisterIndex index, ushort value)
        {
            _io.VbeIndex.Word = (ushort)index;
            _io.VbeData.Word = value;
        }

        private void DisableDisplay()
        {
            Global.mDebugger.SendInternal($"Disabling VBE display");
            Write(RegisterIndex.DisplayEnable, (ushort)EnableValues.Disabled);
            Enabled = false;
        }

        public void Disable() => DisableDisplay();
        public bool Enabled { get; private set; }

        private void SetXResolution(ushort xres)
        {
            Global.mDebugger.SendInternal($"VBE Setting X resolution to {xres}");
            Write(RegisterIndex.DisplayXResolution, xres);
        }

        private void SetYResolution(ushort yres)
        {
            Global.mDebugger.SendInternal($"VBE Setting Y resolution to {yres}");
            Write(RegisterIndex.DisplayYResolution, yres);
        }

        private void SetDisplayBpp(ushort bpp)
        {
            Global.mDebugger.SendInternal($"VBE Setting BPP to {bpp}");
            Write(RegisterIndex.DisplayBpp, bpp);
        }

        private void EnableDisplay(EnableValues enableFlags)
        {
            //Global.mDebugger.SendInternal($"VBE Enabling display with EnableFlags (ushort){EnableFlags}");
            Write(RegisterIndex.DisplayEnable, (ushort)enableFlags);
            Enabled = true;
        }

        public void VbeSet(ushort xres, ushort yres, ushort bpp)
        {
            DisableDisplay();
            SetXResolution(xres);
            SetYResolution(yres);
            SetDisplayBpp(bpp);
            /*
             * Re-enable the Display with LinearFrameBuffer and without clearing video memory of previous value 
             * (this permits to change Mode without losing the previous datas)
             */
            EnableDisplay(EnableValues.Enabled | EnableValues.UseLinearFrameBuffer | EnableValues.NoClearMemory);
        }

        public void SetVram(uint index, byte value)
        {
            Global.mDebugger.SendInternal($"Writing to driver memory in position {index} value {value} (as byte)");
            _io.LinearFrameBuffer.Bytes[index] = value;
        }

        public void SetVram(uint index, ushort value)
        {
            Global.mDebugger.SendInternal($"Writing to driver memory in position {index} value {value} (as ushort)");
            _io.LinearFrameBuffer.Words[index] = value;
        }

        public void SetVram(uint index, uint value)
        {
            //Global.mDebugger.SendInternal($"Writing to driver memory in position {index} value {value} (as uint)");
            _io.LinearFrameBuffer.DWords[index] = value;
        }

        public byte GetVram(uint index)
        {
            return _io.LinearFrameBuffer.Bytes[index];
        }

        public void ClearVram(uint value)
        {
            _io.LinearFrameBuffer.Fill(value);
        }

        public void ClearVram(int aStart, int aCount, int value)
        {
            _io.LinearFrameBuffer.Fill(aStart, aCount, value);
        }

        public void CopyVram(int aStart, int[] aData, int aIndex, int aCount)
        {
            _io.LinearFrameBuffer.Copy(aStart, aData, aIndex, aCount);
        }
    }
#endif
}