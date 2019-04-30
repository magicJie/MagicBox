#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MagicBox.MF.Cfg
{
    [Serializable]
    public class Configuration:ISerializable,IMFConfiguration
    {
        public const string DefaultConfigName = "MF.config";

        #region Field

        private IDictionary<string, object> _configSettings;

        #endregion Field

        #region Propertity
        #endregion Propertity

        #region Method
        //Configuration不依赖ModelFactory，如果存在这个方法，则会产生依赖
        //public ModelFactory BuildModelFactory()
        //{
        //    var currentModelFactory = new ModelFactory(this);
        //    ModelFactory.Current = currentModelFactory;
        //    return currentModelFactory;
        //}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public object GetSetting(string name)
        {
            object obj;
            var isSettingExist = _configSettings.TryGetValue(name,out obj);
            if (!isSettingExist)
            {
                switch (name)
                {
                    case "connectingStr":
                        throw new Exception("未配置连接字符串！");                      
                }
            }
            return _configSettings["name"];
        }


        #endregion Method

        /// <summary>
        /// 获取默认的配置
        /// </summary>
        /// <returns></returns>
        public static Configuration Config()
        {
            return Config(AppDomain.CurrentDomain.BaseDirectory + DefaultConfigName);
        }

        /// <summary>
        /// 根据指定配置文件实例化配置类
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        public static Configuration Config(string configFile)
        {
            var configuration = new Configuration();
            var configSetting = new Dictionary<string, object>();
            configuration._configSettings = configSetting;
            LoadSettings(configFile, configSetting);
            return configuration;
        }

        private static void LoadSettings(string configFile, Dictionary<string, object> configSetting)
        {
            var doc = XDocument.Load(configFile);
            var results = from c in doc.Descendants("connectingStr")
                          select c;
            var s = "";
            foreach (var result in results)
            {
                s = result.Attribute("value").Value; //TODO 这里写法有待确认
            }
            configSetting.Add("connectingStr", s);
        }
        
        #region Static Method

        #endregion

        #region Constructor
        public Configuration()
        {
            //var mfc = ConfigurationManager.GetSection(CfgXmlHelper.CfgSectionName) as IMFConfiguration;
            
        }

        public Configuration(string fileName)
        {

        }

        public Configuration(XmlReader xmlReader)
        {

        }
        #endregion Constructor



       
    }


}
