﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Vision.CameraLib;
using Vision.Forms;


namespace Vision
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (isAlreadyRunning())
            {
                MessageBox.Show("软件已打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HRDVision");
                if (regkey != null)
                {
                  
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Frm_Main form = new Frm_Main();
                    string str1 = "";
                    string str2 = "";
                    string str3 = "";
                    string str4 = "";
                    string str5 = "";

                    try
                    {
                        str1 = regkey.GetValue("Camera1").ToString();
                        str2 = regkey.GetValue("Camera2").ToString();
                        str3 = regkey.GetValue("Camera3").ToString();
                        str4 = regkey.GetValue("Camera4").ToString();
                        str5 = regkey.GetValue("Camera5").ToString();

                    }
                    catch (Exception) { }

                    if (form.cameraManager is FileManager)//文件类相机
                    {
                        switch (regkey.GetValue("Cameras").ToString())
                        {
                            case "1":
                                (form.cameraManager as FileManager).AddCamera(str1);
                                break;
                            case "2":
                                (form.cameraManager as FileManager).AddCamera(str1);
                                (form.cameraManager as FileManager).AddCamera(str2);
                                break;
                            case "3":
                                (form.cameraManager as FileManager).AddCamera(str1);
                                (form.cameraManager as FileManager).AddCamera(str2);
                                (form.cameraManager as FileManager).AddCamera(str3);
                                break;
                            case "4":
                                (form.cameraManager as FileManager).AddCamera(str1);
                                (form.cameraManager as FileManager).AddCamera(str2);
                                (form.cameraManager as FileManager).AddCamera(str3);
                                (form.cameraManager as FileManager).AddCamera(str4);
                                break;
                            case "5":
                                (form.cameraManager as FileManager).AddCamera(str1);
                                (form.cameraManager as FileManager).AddCamera(str2);
                                (form.cameraManager as FileManager).AddCamera(str3);
                                (form.cameraManager as FileManager).AddCamera(str4);
                                (form.cameraManager as FileManager).AddCamera(str5);
                                break;
                            default:
                                break;
                        }
                        try
                        {
                            form.cameraManager.OpenAll();//打开所有相机
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("系统异常");
                            return;
                        }

                        form.SetCameraWindows(form.cameraManager.listCamera.Count);//设置相机窗体样式
                        GetWin(form.cameraWin, form.cameraManager.listCamera, str1, str2, str3, str4, str5);//获得相机的窗体
                        Thread.Sleep(500);
                        Application.Run(form);

                    }
                    else if (form.cameraManager is DahengManager || form.cameraManager is DahuaManager)//大恒、大华相机
                    {
                        switch (regkey.GetValue("Cameras").ToString())
                        {
                            case "1":
                                ChangeList(form.cameraManager.listCamera, str1, 0);
                                form.cameraManager.listCamera.RemoveAll(cam => cam.strName != str1);//移除相机
                                break;
                            case "2":
                                ChangeList(form.cameraManager.listCamera, str1, 0);
                                ChangeList(form.cameraManager.listCamera, str2, 1);
                                form.cameraManager.listCamera.RemoveAll(cam => cam.strName != str1 && cam.strName != str2);//移除相机
                                break;
                            case "3":
                                ChangeList(form.cameraManager.listCamera, str1, 0);
                                ChangeList(form.cameraManager.listCamera, str2, 1);
                                ChangeList(form.cameraManager.listCamera, str3, 2);
                                form.cameraManager.listCamera.RemoveAll(cam => cam.strName == str4 || cam.strName == str5);//移除相机
                                break;
                            case "4":
                                ChangeList(form.cameraManager.listCamera, str1, 0);
                                ChangeList(form.cameraManager.listCamera, str2, 1);
                                ChangeList(form.cameraManager.listCamera, str3, 2);
                                ChangeList(form.cameraManager.listCamera, str4, 3);
                                form.cameraManager.listCamera.RemoveAll(cam => cam.strName == str5);//移除相机
                                break;
                            case "5":
                                ChangeList(form.cameraManager.listCamera, str1, 0);
                                ChangeList(form.cameraManager.listCamera, str2, 1);
                                ChangeList(form.cameraManager.listCamera, str3, 2);
                                ChangeList(form.cameraManager.listCamera, str4, 3);
                                ChangeList(form.cameraManager.listCamera, str5, 4);
                                break;
                            default:
                                MessageBox.Show("系统异常");
                                return;
                        }
                        form.cameraManager.OpenAll();//打开所有相机
                        if (form.cameraManager is DahuaManager)
                        {
                            foreach (var camera in form.cameraManager.listCamera)
                            {
                                camera.Grad();//开始采集
                                (camera as Dahua).SetExposureTime(regkey.GetValue($"ExposureTime{camera.Index + 1}").ToString());//设置曝光
                                (camera as Dahua).SetGainRaw(regkey.GetValue($"GainRaw{camera.Index + 1}").ToString());//设置增益

                            }
                        }
                        if (form.cameraManager is DahengManager)
                        {
                            foreach (var camera in form.cameraManager.listCamera)
                            {
                                (camera as Daheng).StartDevice();//开始采集
                                (camera as Daheng).SetExposureTime(regkey.GetValue($"ExposureTime{camera.Index + 1}").ToString());//设置曝光
                                (camera as Daheng).SetGainRaw(regkey.GetValue($"GainRaw{camera.Index + 1}").ToString());//设置增益
                            }
                        }
                        form.SetCameraWindows(form.cameraManager.listCamera.Count);//设置相机窗体样式

                        GetWin(form.cameraWin, form.cameraManager.listCamera, str1, str2, str3, str4, str5);//获得相机的窗体

                        Thread.Sleep(500);
                        Application.Run(form);
                    }

                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Frm_CameraConfig());
                }

            }
        }

        /// <summary>
        /// 判断软件是否已经运行
        /// </summary>
        /// <returns></returns>
        private static bool isAlreadyRunning()
        {
            bool b = false;
            Process[] mProcs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (mProcs.Length > 1)
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// 大恒类、大华类改变相机的顺序
        /// </summary>
        /// <param name="cameras">相机集合</param>
        /// <param name="str">序列号</param>
        /// <param name="index">索引</param>
        public static void ChangeList(List<Camera> cameras, string str, int index)
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                if (str == cameras[i].strName)
                {
                    var temp = cameras[i];
                    cameras[i] = cameras[index];

                    cameras[index] = temp;
                    cameras[index].Index = index;
                }
            }
        }

        /// <summary>
        /// 获得相机的窗体
        /// </summary>
        /// <param name="cameraWin">相机样式窗体</param>
        /// <param name="cameras">相机集合</param>
        /// <param name="vs">相机名称集合</param>
        public static void GetWin(Form cameraWin, List<Camera> cameras, params string[] vs)  
        {
            switch (cameras.Count)
            {
                case 1:
                    Frm_OneWin form1 = cameraWin as Frm_OneWin;
                    cameras[0].SetWindow(vs[0], form1.h_Windows[0], form1.labels_OK[0], form1.labels_Sum[0], form1.labels_Num[0], form1.labels_Yield[0]);
                    break;
                case 2:
                    Frm_TwoWin form2 = cameraWin as Frm_TwoWin;
                    cameras[0].SetWindow(vs[0], form2.h_Windows[0], form2.labels_OK[0], form2.labels_Sum[0], form2.labels_Num[0], form2.labels_Yield[0]);
                    cameras[1].SetWindow(vs[1], form2.h_Windows[1], form2.labels_OK[1], form2.labels_Sum[1], form2.labels_Num[1], form2.labels_Yield[1]);
                    break;
                case 3:
                    Frm_ThreeWin form3 = cameraWin as Frm_ThreeWin;
                    cameras[0].SetWindow(vs[0], form3.h_Windows[0], form3.labels_OK[0], form3.labels_Sum[0], form3.labels_Num[0], form3.labels_Yield[0]);
                    cameras[1].SetWindow(vs[1], form3.h_Windows[1], form3.labels_OK[1], form3.labels_Sum[1], form3.labels_Num[1], form3.labels_Yield[1]);
                    cameras[2].SetWindow(vs[2], form3.h_Windows[2], form3.labels_OK[2], form3.labels_Sum[2], form3.labels_Num[2], form3.labels_Yield[2]);
                 
                    break;
                case 4:
                    Frm_FourWin form4 = cameraWin as Frm_FourWin;
                    cameras[0].SetWindow(vs[0], form4.h_Windows[0], form4.labels_OK[0], form4.labels_Sum[0], form4.labels_Num[0], form4.labels_Yield[0]);
                    cameras[1].SetWindow(vs[1], form4.h_Windows[1], form4.labels_OK[1], form4.labels_Sum[1], form4.labels_Num[1], form4.labels_Yield[1]);
                    cameras[2].SetWindow(vs[2], form4.h_Windows[2], form4.labels_OK[2], form4.labels_Sum[2], form4.labels_Num[2], form4.labels_Yield[2]);
                    cameras[3].SetWindow(vs[3], form4.h_Windows[3], form4.labels_OK[3], form4.labels_Sum[3], form4.labels_Num[3], form4.labels_Yield[3]);

                    break;
                case 5:
                    Frm_FiveWin form5 = cameraWin as Frm_FiveWin;
                    cameras[0].SetWindow(vs[0], form5.h_Windows[0], form5.labels_OK[0], form5.labels_Sum[0], form5.labels_Num[0], form5.labels_Yield[0]);
                    cameras[1].SetWindow(vs[1], form5.h_Windows[1], form5.labels_OK[1], form5.labels_Sum[1], form5.labels_Num[1], form5.labels_Yield[1]);
                    cameras[2].SetWindow(vs[2], form5.h_Windows[2], form5.labels_OK[2], form5.labels_Sum[2], form5.labels_Num[2], form5.labels_Yield[2]);
                    cameras[3].SetWindow(vs[3], form5.h_Windows[3], form5.labels_OK[3], form5.labels_Sum[3], form5.labels_Num[3], form5.labels_Yield[3]);
                    cameras[4].SetWindow(vs[4], form5.h_Windows[4], form5.labels_OK[4], form5.labels_Sum[4], form5.labels_Num[4], form5.labels_Yield[4]);
                    break;
                default:
                    break;
            }
        }

    }
}
