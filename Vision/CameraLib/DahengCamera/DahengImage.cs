using GxIAPINET;
using HalconDotNet;
using System;
using System.Runtime.InteropServices;

namespace Vision.CameraLib
{
    /// <summary>
    /// 大恒图像类
    /// </summary>
    public class DahengImage
    {
        const uint PIXEL_FORMATE_BIT = 0x00FF0000;          ///<用于与当前的数据格式进行与运算得到当前的数据位数
        const uint GX_PIXEL_8BIT = 0x00080000;          ///<8位数据图像格式

        IGXDevice m_objIGXDevice = null;                ///<设备对像
        int nWidth = 0;                   ///<图像宽度
        int nHeigh = 0;                   ///<图像高度

        byte[] m_byMonoBuffer = null;                ///<黑白相机buffer
      
        public DahengImage(IGXDevice objIGXDevice)
        {
          
            m_objIGXDevice = objIGXDevice;

            if (null != objIGXDevice)
            {
                //获得图像原始数据大小、宽度、高度等

                nWidth = (int)objIGXDevice.GetRemoteFeatureControl().GetIntFeature("Width").GetValue();
                nHeigh = (int)objIGXDevice.GetRemoteFeatureControl().GetIntFeature("Height").GetValue();
            }

            m_byMonoBuffer = new byte[nWidth * nHeigh];
        }

        public HObject Show(IBaseData objIBaseData)
        {
            GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
            if (null != objIBaseData)
            {
                emValidBits = GetBestValudBit(objIBaseData.GetPixelFormat());
                if (GX_FRAME_STATUS_LIST.GX_FRAME_STATUS_SUCCESS == objIBaseData.GetStatus())
                {
                    IntPtr pBufferMono = IntPtr.Zero;
                    if (IsPixelFormat8(objIBaseData.GetPixelFormat()))
                    {
                        pBufferMono = objIBaseData.GetBuffer();
                    }
                    else
                    {
                        pBufferMono = objIBaseData.ConvertToRaw8(emValidBits);
                    }
                    Marshal.Copy(pBufferMono, m_byMonoBuffer, 0, nWidth * nHeigh);

                    unsafe
                    {
                        fixed (byte* p = m_byMonoBuffer)
                        {
                            HOperatorSet.GenEmptyObj(out HObject image);
                            image.Dispose();
                            HOperatorSet.GenImage1(out image, "byte", nWidth, nHeigh, new IntPtr(p));
                            return image;
                        }

                    }
                }
            }
            return null;
        }



        private GX_VALID_BIT_LIST GetBestValudBit(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
            switch (emPixelFormatEntry)
            {
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG8:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG10:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_2_9;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG12:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_4_11;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO14:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG16:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                default:
                    break;
            }
            return emValidBits;
        }

        private bool IsPixelFormat8(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            bool bIsPixelFormat8 = false;
            uint uiPixelFormatEntry = (uint)emPixelFormatEntry;
            if ((uiPixelFormatEntry & PIXEL_FORMATE_BIT) == GX_PIXEL_8BIT)
            {
                bIsPixelFormat8 = true;
            }
            return bIsPixelFormat8;
        }
    }
}
