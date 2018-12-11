using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.SQLHelp
{
    public class DataReaderProcess
    {
        /// <summary>
        /// DataReader转换为obj list  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sdr"></param>
        /// <returns></returns>
        public static IList<T> DataReaderToList<T>(SqlDataReader sdr)
        {
            IList<T> list = new List<T>();

            while (sdr.Read())
            {
                T t = System.Activator.CreateInstance<T>();
                
                Type obj = t.GetType();
                // 循环字段  
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    object tempValue = null;

                    if (sdr.IsDBNull(i))
                    {
                        //string typeFullName = obj.GetProperty(sdr.GetName(i)).PropertyType.FullName;
                        //tempValue = GetDBNullValue(typeFullName);
                        continue;
                    }
                    else
                    {
                        tempValue = sdr.GetValue(i);
                    }

                    obj.GetProperty(sdr.GetName(i)).SetValue(t, tempValue, null);
                }
                list.Add(t);
            }
            return list;
        }


        /// <summary>  
        /// DataReader转换为obj  
        /// </summary>  
        /// <typeparam name="T">泛型</typeparam>  
        /// <param name="sdr">datareader</param>  
        /// <returns>返回泛型类型</returns>  
        public static object DataReaderToObj<T>(SqlDataReader sdr)
        {
            T t = System.Activator.CreateInstance<T>();
            Type obj = t.GetType();

            if (sdr.Read())
            {
                // 循环字段  
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    object tempValue = null;

                    if (sdr.IsDBNull(i))
                    {
                        //string typeFullName = obj.GetProperty(sdr.GetName(i)).PropertyType.FullName;
                        //tempValue = GetDBNullValue(typeFullName);
                        continue;
                    }
                    else
                    {
                        tempValue = sdr.GetValue(i);
                    }
                    try
                    {
                        string d = sdr.GetName(i);
                        obj.GetProperty(sdr.GetName(i)).SetValue(t, tempValue, null);
                    }
                    catch (Exception)
                    {   }
                }
                return t;
            }
            else
                return null;
        }

        /// <summary>  
        /// 返回值为DBnull的默认值  
        /// </summary>  
        /// <param name="typeFullName">数据类型的全称，类如：system.int32</param>  
        /// <returns>返回的默认值</returns>  
        //private static object GetDBNullValue(string typeFullName)
        //{
        //    typeFullName = typeFullName.ToLower();

        //    if (typeFullName == Type.)
        //    {
        //        return String.Empty;
        //    }
        //    if (typeFullName == DataType.Int32)
        //    {
        //        return 0;
        //    }
        //    if (typeFullName == DataType.DateTime)
        //    {
        //        return Convert.ToDateTime(BaseSet.DateTimeLongNull);
        //    }
        //    if (typeFullName == DataType.Boolean)
        //    {
        //        return false;
        //    }
        //    if (typeFullName == DataType.Int)
        //    {
        //        return 0;
        //    }

        //    return null;
        //}
    }
}
