using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace SandBox_202124070
{
    [Serializable]
    class UntrustedClass : MarshalByRefObject
    {
        public IPlugin AssignFileName(string filePath)
        {
            //File.Exists(assignFileName);

            Assembly ass = Assembly.LoadFile(filePath);
            foreach(Type type in ass.GetTypes())
            {
                if(type.IsClass && !type.IsAbstract && type.GetInterfaces().Contains(typeof(IPlugin)))
                {
                    ConstructorInfo con = type.GetConstructor(Type.EmptyTypes);
                    IPlugin plugIn = (IPlugin)con.Invoke(null);
                    return plugIn;
                }
            }
            return null;
        }

        ~UntrustedClass()
        {

        }
    }

    public interface IPlugin
    {
    }
}
