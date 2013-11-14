using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OOPA.Factory
{
    public class FactoryMethod<TKey, TObject>
        where TObject : ICloneable, IGetKey<TKey>
    {
        public static TObject create(TKey cKey)
        {
            return instance()._create(cKey);
        }

        private FactoryMethod()
        {
            m_caObjectMap = new Dictionary<TKey, TObject>();
        }

        private static FactoryMethod<TKey, TObject> instance()
        {
            if (m_cInstance == null)
            {
                m_cInstance = new FactoryMethod<TKey, TObject>();

                m_cInstance.initialize();
            }

            return m_cInstance;
        }

        private TObject _create(TKey cKey)
        {
            if (m_caObjectMap.ContainsKey(cKey))
            {
                TObject cObject = m_caObjectMap[cKey];

                return (TObject)cObject.Clone();
            }
            else
                return default(TObject);
        }

        private void initialize()
        {
            Type[] caType = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            Type cBaseType = typeof(TObject);

            foreach (Type type in caType)
            {
                if (!type.IsPrimitive && type.BaseType == cBaseType)
                {
                    ConstructorInfo[] constructorInfo = type.GetConstructors();

                    for (int n = 0; n < constructorInfo.Length; n++)
                    {
                        if (constructorInfo[n].GetParameters().Length == 0)
                        {
                            TObject cObject = (TObject)constructorInfo[n].Invoke(null);

                            m_caObjectMap.Add(cObject.getKey(), cObject);
                        }
                    }
                }
            }
        }

        private Dictionary<TKey, TObject> m_caObjectMap;
        static private FactoryMethod<TKey, TObject> m_cInstance = null;
    }

    public interface IGetKey<TKey>
    {
        TKey getKey();
    }
}
