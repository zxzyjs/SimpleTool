﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSqlSugar
{
    public static class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return Encoding.UTF8.GetBytes(jsonString);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEntity Deserialize<TEntity>(byte[] value)
        {
            if (value == null)
            {
                return default(TEntity);
            }
            var jsonString = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject<TEntity>(jsonString);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEntity StringDeserialize<TEntity>(this string value)
        {
            if (value == null)
            {
                return default(TEntity);
            }
            return JsonConvert.DeserializeObject<TEntity>(value);
        }


        /// <summary>
        /// List字符串转数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string value)
        {
            List<T> list = new List<T>();
            try
            {
                list = StringDeserialize<List<T>>(value);

            }
            catch { }
            return list;
        }
    }
}