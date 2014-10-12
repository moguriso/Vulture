using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Vulture
{
    public struct recodeSetting
    {
        public bool isEnable;

        public string saveDir;

        public bool isWeekly;

        public string title;
        public string channel;
        public string inDevice;

        public DateTime startDate;
        public DateTime endDate;
        public bool isSetEndDate;

        public DateTime startTime;
        public DateTime endTime;

        public int recStartMergin;
        public int recEndMergin;
        public int ctrlSendMergin;
    }

    class CtrlParam
    {
        #region basic_params

        private static CtrlParam instance = new CtrlParam();
        private AutoResetEvent formSync = new AutoResetEvent(false);
        private recodeSetting currentSetting = new recodeSetting();

        #endregion

        #region property
        public AutoResetEvent arSync
        {
            get
            {
                return this.formSync;
            }
        }

        public string curTitle
        {
            get
            {
                return currentSetting.title;
            }
        }

        public string curRecDateTime
        {
            get
            {
                DateTime startDate = currentSetting.startDate;
                DateTime startTime = currentSetting.startTime;
                DateTime endDate = currentSetting.endDate;
                DateTime endTime = currentSetting.endTime;

                string rStr;
                rStr = String.Format("{0}/{1:D2}/{2:D2} {3:D2}:{4:D2}",
                    startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute);

                return rStr;
            }
        }

        public string curNextTime
        {
            get
            {
                string rStr;
                TimeSpan ts;
                DateTime startTime = DateTime.Now;
                DateTime endTime = currentSetting.startTime;
                ts = endTime - startTime;
                if (ts.Hours > 0)
                {
                    double ddd = Convert.ToDouble(ts.Hours*60) + Convert.ToDouble(ts.Minutes);
                    ddd = ddd / 60.0;
                    rStr = String.Format("{0:F1}時間", ddd);
                }
                else
                {
                    rStr = String.Format("{0}分", ts.Minutes);
                }
                return rStr;
            }
        }

        public string curRecTime
        {
            get
            {
                TimeSpan ts;
                string rStr;
                DateTime startTime = currentSetting.startTime;
                DateTime endTime = currentSetting.endTime;
                double ddd;

                ts = endTime - startTime;

                ddd = Convert.ToDouble(ts.Hours * 60) + Convert.ToDouble(ts.Minutes);

                rStr = String.Format("{0:F0}分", ddd);

                return rStr;
            }
        }

        public string curInDevice
        {
            get
            {
                return currentSetting.inDevice;
            }
        }

        public string curChannel
        {
            get
            {
                return currentSetting.channel;
            }
        }
        #endregion


        public CtrlParam()
        {
        }

        ~CtrlParam()
        {
        }

        public static CtrlParam getInstance()
        {
            return instance;
        }

        public bool setRecSetting( bool isEnable,       string saveDir,
                                   bool isWeekly,       string title,
                                   string channel,      string inDevice,
                                   DateTime startDate,  DateTime endDate,
                                   bool isSetEndDate,   DateTime startTime,
                                   DateTime endTime,    int recStartMergin,
                                   int recEndMergin,    int ctrlSendMergin)
        {
            bool r_inf = true;

            try
            {
                currentSetting.isEnable = isEnable;
                currentSetting.saveDir = saveDir;
                currentSetting.isWeekly = isWeekly;
                currentSetting.title = title;
                currentSetting.channel = channel;
                currentSetting.inDevice = inDevice;
                currentSetting.startDate = startDate;
                currentSetting.endDate = endDate;
                currentSetting.isSetEndDate = isSetEndDate;
                currentSetting.startTime = startTime;
                currentSetting.endTime = endTime;
                currentSetting.recStartMergin = recStartMergin;
                currentSetting.recEndMergin = recEndMergin;
                currentSetting.ctrlSendMergin = ctrlSendMergin;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                r_inf = false;
            }

            return r_inf;
        }
    }
}
