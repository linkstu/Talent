using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Talent.Util
{
    /// <summary>
    /// INI操作
    /// </summary>
    public class INI
    {
        #region 外部导入函数
        //对ini文件进行写操作的函数
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //对ini文件进行读操作的函数
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region INI操作
        private readonly string m_fileName;  //用于存放ini文件的路径和名称
        private Hashtable m_sections; //用于存放整个ini文件的内容

        public string FileName
        {
            get
            {
                return m_fileName;
            }
        }

        /// <summary>
        /// IniFile的构造函数
        /// </summary>
        /// <param name="fileName">ini文件的路径和名称</param>
        public INI(string fileName)
        {
            m_fileName = fileName;
            m_sections = new Hashtable();
            LoadValues();
        }
        ~INI()
        {
            m_sections = null;
        }

        /// <summary>
        /// 装载Ini文件的内容
        /// </summary>
        private void LoadValues()
        {
            if ((m_fileName.Trim() != "") && (File.Exists(m_fileName)))
            {

                using StreamReader sr = new(m_fileName);
                SetStrings(sr);
            }
        }

        /// <summary>
        /// 添加一个ini文件的Section
        /// </summary>
        /// <param name="item">section的名字</param>
        /// <returns>添加的section</returns>
        private Hashtable AddSection(string item)
        {
            Hashtable sectionsItem = new();
            m_sections.Add(item, sectionsItem);
            return sectionsItem;
        }

        /// <summary>
        /// 将ini文件的内容读取到内存当中
        /// </summary>
        /// <param name="sr">读取文件的流</param>
        private void SetStrings(StreamReader sr)
        {
            String line;
            Hashtable sectionsKeys = null;
            int splitPos;
            string keyName, keyValue;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();

                if (line == "") continue;

                if (line[..1] != ";")
                {
                    if ((line[..1] == "[") && (line.Substring(line.Length - 1, 1) == "]"))
                    {
                        line = line[1..^1];
                        sectionsKeys = AddSection(line.Trim());
                    }

                    else
                    {
                        splitPos = line.IndexOf('=');
                        if ((splitPos > 0) && (sectionsKeys != null))
                        {
                            keyName = line[..splitPos].Trim();

                            if (keyName.Length == 0)
                            {
                                throw new Exception("IniFile Syntax Error!");
                            }

                            if (keyName.Length < line.Length - 1)
                            {
                                keyValue = line.Substring(splitPos + 1, line.Length - 1 - splitPos);
                            }
                            else
                            {
                                keyValue = "";
                            }
                            sectionsKeys.Add(keyName, keyValue);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 将内容写回到Ini文件当中
        /// </summary>
        public void Update()
        {
            Hashtable sectionsItem;

            if (File.Exists(m_fileName))
            {
                File.Delete(m_fileName);
            }

            using StreamWriter sw = new(m_fileName);
            foreach (DictionaryEntry scnItem in m_sections)
            {
                sw.WriteLine("[" + (string)scnItem.Key + "]");

                sectionsItem = (Hashtable)m_sections[(string)scnItem.Key];
                foreach (DictionaryEntry keyItem in sectionsItem)
                {
                    sw.WriteLine((string)keyItem.Key + "=" + (string)keyItem.Value);
                }

                sw.WriteLine("");
            }
            sw.Close();
        }

        /// <summary>
        /// 读取Ini文件所有的section
        /// </summary>
        /// <returns>以ArrayList形式返回以字符串表示的section</returns>
        public ArrayList ReadSections()
        {
            ArrayList sectionList = new();

            foreach (DictionaryEntry item in m_sections)
            {
                sectionList.Add((string)item.Key);
            }
            return sectionList;
        }

        /// <summary>
        /// 读取Ini文件的一个section中的所有key
        /// </summary>
        /// <param name="sectionName">要读取的section</param>
        /// <returns>以ArrayList形式返回以字符串表示的kry</returns>
        public ArrayList ReadKeys(string sectionName)
        {
            ArrayList keyList = new();

            Hashtable sectionsItem = (Hashtable)m_sections[sectionName.Trim()];

            foreach (DictionaryEntry item in sectionsItem)
            {
                keyList.Add((string)item.Key);
            }

            return keyList;
        }

        /// <summary>
        /// 判断一个section是否存在
        /// </summary>
        /// <param name="sectionName">要检查的section的名字</param>
        /// <returns>如果section存在,则返回true,否则返回false</returns>
        public bool SectionExists(string sectionName)
        {
            return m_sections.ContainsKey(sectionName.Trim());
        }

        /// <summary>
        /// 判断一个key在一个section中是否存在
        /// </summary>
        /// <param name="sectionName">所指定的section</param>
        /// <param name="keyName">所要检查的key的名字</param>
        /// <returns>如果此key在这个section中存在,则返回true,否则返回false</returns>
        public bool KeyExists(string sectionName, string keyName)
        {
            sectionName = sectionName.Trim();

            if (!m_sections.ContainsKey(sectionName))
            {
                return false;
            }

            return ((Hashtable)m_sections[sectionName]).ContainsKey(keyName.Trim());
        }

        /// <summary>
        /// 删除一个section
        /// </summary>
        /// <param name="sectionName">所要删除的section的名字</param>
        public void EraseSection(string sectionName)
        {
            m_sections.Remove(sectionName);
        }

        /// <summary>
        ///在一个sectionk中删除一个key
        /// </summary>
        /// <param name="sectionName">所指定的section</param>
        /// <param name="keyName">所要删除的key的名字</param>
        public void DeleteKey(string sectionName, string keyName)
        {
            sectionName = sectionName.Trim();

            if (!m_sections.ContainsKey(sectionName))
            {
                return;
            }

            ((Hashtable)m_sections[sectionName]).Remove(keyName.Trim());
        }

        public string ReadString(string sectionName, string keyName, string defaultValue)
        {
            sectionName = sectionName.Trim();
            keyName = keyName.Trim();

            if (!m_sections.ContainsKey(sectionName))
            {
                return defaultValue;
            }

            Hashtable sectionsItem = (Hashtable)m_sections[sectionName];
            if (!sectionsItem.ContainsKey(keyName))
            {
                return defaultValue;
            }

            return (string)sectionsItem[keyName];
        }

        public void WriteString(string sectionName, string keyName, string stringValue)
        {
            Hashtable sectionsItem;

            sectionName = sectionName.Trim();
            keyName = keyName.Trim();
            stringValue = stringValue.Trim();


            if (!m_sections.ContainsKey(sectionName))
            {
                sectionsItem = AddSection(sectionName);
            }
            else
            {
                sectionsItem = (Hashtable)m_sections[sectionName];
            }
            //if (!sectionsItem.ContainsKey(keyName))
            if (sectionsItem.ContainsKey(keyName))
            {
                sectionsItem[keyName] = stringValue;
            }
            else
            {
                sectionsItem.Add(keyName, stringValue);
            }
        }

        public long ReadInteger(string sectionName, string keyName, long defaultValue)
        {
            return Convert.ToInt64(ReadString(sectionName, keyName, Convert.ToString(defaultValue)));
        }

        public void WriteInteger(string sectionName, string keyName, long longValue)
        {
            WriteString(sectionName, keyName, Convert.ToString(longValue));
        }

        public bool ReadBool(string sectionName, string keyName, bool defaultValue)
        {
            return Convert.ToBoolean(ReadString(sectionName, keyName, Convert.ToString(defaultValue)));
        }

        public void WriteBool(string sectionName, string keyName, bool boolValue)
        {
            WriteString(sectionName, keyName, Convert.ToString(boolValue));
        }

        public DateTime ReadDate(string sectionName, string keyName, DateTime defaultValue)
        {
            return Convert.ToDateTime(ReadString(sectionName, keyName, Convert.ToString(defaultValue))).Date;
        }

        public void WriteDate(string sectionName, string keyName, DateTime dateValue)
        {
            WriteString(sectionName, keyName, Convert.ToString(dateValue.Date));
        }

        public DateTime ReadDateTime(string sectionName, string keyName, DateTime defaultValue)
        {
            return Convert.ToDateTime(ReadString(sectionName, keyName, Convert.ToString(defaultValue)));
        }

        public void WriteDateTime(string sectionName, string keyName, DateTime dateTimeValue)
        {
            WriteString(sectionName, keyName, Convert.ToString(dateTimeValue));
        }

        public double ReadFloat(string sectionName, string keyName, double defaultValue)
        {
            return Convert.ToDouble(ReadString(sectionName, keyName, Convert.ToString(defaultValue)));
        }

        public void WriteFloat(string sectionName, string keyName, double doubleValue)
        {
            WriteString(sectionName, keyName, Convert.ToString(doubleValue));
        }

        public DateTime ReadTime(string sectionName, string keyName, DateTime defaultValue)
        {
            return Convert.ToDateTime(ReadString(sectionName, keyName, Convert.ToString(defaultValue)));
        }

        public void WriteTime(string sectionName, string keyName, DateTime timeValue)
        {
            WriteString(sectionName, keyName, Convert.ToString(timeValue.TimeOfDay));
        }
        #endregion
    }
}
