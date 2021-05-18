using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Valve.VR;


using System.IO;
using Device = SharpDX.Direct3D11.Device;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.Windows;
using System.Threading;

namespace Trans
{

    class Overlay
    {

        private const int XS = 1024;
        private const int YS = 1536;

        public static frm_trans Instance { get; private set; } = null;
        private static RenderTarget m_RenderTarget;
        private static RenderTarget m_RenderTarget2;
        private static SwapChain m_SwapChain;
        private static Texture2D m_BackBuffer;
        private static Texture2D m_BackBuffer2;
        private static RenderForm m_RenderForm;
        private static Device m_Device;

        public static string transtext = "hello";
        public static bool transof = true;

        public static void ChangeTxt(string txtmsg)
        {
            transtext = txtmsg;
        }

        public static bool Overlay_Init()
        {

            var error = EVRInitError.None;
            OpenVR.Init(ref error, EVRApplicationType.VRApplication_Overlay);
            if (error != EVRInitError.None) return false;

            return true;

        }

        public void Overlay_Close()
        {
            OpenVR.Shutdown();
        }

        public static void Overlay_Send()
        {

            var overlay = OpenVR.Overlay;
            ulong handle = 0;           

            if (overlay.FindOverlay("Trans", ref handle) != EVROverlayError.None &&
                overlay.CreateOverlay("Trans", "Trans", ref handle) == EVROverlayError.None)
            {
                overlay.SetOverlayAlpha(handle, 0.5f);
                overlay.SetOverlayWidthInMeters(handle, 2f);
                overlay.SetOverlayInputMethod(handle, VROverlayInputMethod.None);
                overlay.ClearOverlayTexture(handle);
            }
            if (handle != 0)
            {
                var m = Matrix.Scaling(1f);
                m *= Matrix.Translation(0, -0.5f, -2f);
                var hm34 = new HmdMatrix34_t
                {
                    m0 = m.M11,
                    m1 = m.M21,
                    m2 = m.M31,
                    m3 = m.M41,
                    m4 = m.M12,
                    m5 = m.M22,
                    m6 = m.M32,
                    m7 = m.M42,
                    m8 = m.M13,
                    m9 = m.M23,
                    m10 = m.M33,
                    m11 = m.M43,
                };
                overlay.SetOverlayTransformTrackedDeviceRelative(handle, OpenVR.k_unTrackedDeviceIndex_Hmd, ref hm34);
                var texture = new Texture_t
                {
                    handle = m_BackBuffer2.NativePointer
                };
                overlay.SetOverlayTexture(handle, ref texture);
                overlay.ShowOverlay(handle);
                
                if (!transof) overlay.HideOverlay(handle);
            }
        }
        
        [STAThread]
        public static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new frm_trans();
            frm_trans.Instance.Show();
            
            Application.DoEvents();
            
            Device.CreateWithSwapChain(SharpDX.Direct3D.DriverType.Hardware, DeviceCreationFlags.BgraSupport, new[] {
                SharpDX.Direct3D.FeatureLevel.Level_10_0
            }, new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(XS, YS, new Rational(30, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputHandle = frm_trans.Instance.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            }, out m_Device, out m_SwapChain);
            
            m_SwapChain.GetParent<SharpDX.DXGI.Factory>().MakeWindowAssociation(frm_trans.Instance.Handle, WindowAssociationFlags.IgnoreAll);
            m_BackBuffer2 = new Texture2D(m_Device, new Texture2DDescription()
            {
                Width = 1024,
                Height = 1024,
                MipLevels = 1,
                ArraySize = 1,
                Format = Format.R8G8B8A8_UNorm,
                SampleDescription = new SampleDescription(1, 0),
                BindFlags = BindFlags.RenderTarget
            });

            var factory2D = new SharpDX.Direct2D1.Factory();

            using (var surface = m_BackBuffer2.QueryInterface<Surface>())
            {
                m_RenderTarget2 = new RenderTarget(factory2D, surface, new RenderTargetProperties(new PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)))
                {
                    TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode.Cleartype,
                    AntialiasMode = AntialiasMode.PerPrimitive
                };
            }

            // fonts
            var factoryDW = new SharpDX.DirectWrite.Factory();

            var textFormat4 = new TextFormat(factoryDW, "Arial", FontWeight.Bold, FontStyle.Normal, 48)
            {
                WordWrapping = WordWrapping.Wrap,
                ParagraphAlignment = ParagraphAlignment.Far,
                TextAlignment = TextAlignment.Center,
            };
            
            SolidColorBrush blackBrush2 = new SolidColorBrush(m_RenderTarget2, Color.Black);
            SolidColorBrush whiteBrush2 = new SolidColorBrush(m_RenderTarget2, Color.White);

            // colors
            Color backColor = new Color(0.15f, 0.15f, 0.15f, 1);

            
            while(true)
            {
                Application.DoEvents();
                
                if (Overlay_Init())
                {

                        m_RenderTarget2.BeginDraw();
                        m_RenderTarget2.Clear(null);
                        
                        m_RenderTarget2.FillRectangle(new RawRectangleF(100, 600, 1024, 680), blackBrush2);

                        m_RenderTarget2.DrawText(transtext, textFormat4, new RawRectangleF(100, 630 ,1024,685), whiteBrush2, DrawTextOptions.Clip);

                        m_RenderTarget2.EndDraw();

                        Overlay_Send();
               }
           }
       }
   }
}

