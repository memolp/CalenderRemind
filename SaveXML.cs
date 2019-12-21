using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Calendar
{
    public class SaveXML<type>
    {


        BinaryFormatter formatter;

        public SaveXML() {
            formatter = new BinaryFormatter();
        }

        public void SaveData(Dictionary<int, List<Event>> obj, String filename)
        {

            try
            {
                // Create a FileStream that will write data to file.
                FileStream writerFileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                // Save our dictionary of friends to file
                this.formatter.Serialize(writerFileStream, obj);

                // Close the writerFileStream when we are done.
                writerFileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().ToString());
            } // end try-catch
        }

        public Dictionary<int, List<Event>> GetData(Dictionary<int, List<Event>> o, String filename)
        {
            try
            {
                // Create a FileStream will gain read access to the 
                // data file.
                FileStream readerFileStream = new FileStream(filename,
                    FileMode.Open, FileAccess.Read);
                // Reconstruct information of our friends from file.
                var dict = (Dictionary<int, List<Event>>)this.formatter.Deserialize(readerFileStream);
                // Close the readerFileStream when we are done
                readerFileStream.Close();

                return dict;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetBaseException().ToString());
            } // en

            return new Dictionary<int, List<Event>>();
        }

        
    }
}
