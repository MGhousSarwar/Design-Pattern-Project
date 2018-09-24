using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Dp_project.Classes
{
    class Cserialize
    {
        public C_Db deserialize()
        {
            C_Db newobj = null;
            FileStream fs = new FileStream("db.bat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                newobj = (C_Db)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                fs.Close();
                newobj = new C_Db();

                serialize(newobj);

            }
            finally
            {
                fs.Close();
            }

            return newobj;
        }
        public void serialize(C_Db obj)
        {

            FileStream fs = new FileStream("db.bat", FileMode.OpenOrCreate);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize . Reason: " + ex.ToString());
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
