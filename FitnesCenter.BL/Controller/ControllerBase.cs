using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesCenter.BL.Controller
{
    public abstract class ControllerBase
    {
        //protected void Save<T>(string fileName, List<T> item) - first variant
        //may have to save not only collections
        protected void Save(string fileName, object item) // - univeral variant 
        {
            var binFormatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, item);
            }
        }
        protected T Load<T>(string fileName)
        {
            var binFormatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && binFormatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
