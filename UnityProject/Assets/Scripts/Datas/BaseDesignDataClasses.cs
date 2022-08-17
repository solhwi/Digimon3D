
/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignData
{
    
    public abstract class BaseData<DataType> where DataType : BaseData<DataType>
    {
        public abstract void Load(List<DataType> Datas);
    }


    
    public abstract class BaseExcelData<DataType> : BaseData<DataType> where DataType : BaseExcelData<DataType>
    {
        public int DDId { get; set; }
        
        protected Dictionary<int /*DDId*/, DataType> Container = new Dictionary<int /*DDId*/, DataType>();

        public override void Load(List<DataType> Datas)
        {
            Container.Clear();
            foreach(var Data in Datas)
            {
                Container.Add(Data.DDId, Data);
            }
        }

        public DataType Get(int DDId)
        {
            return Container[DDId];
        }

        public bool Has(int DDId)
        {
            return Container.ContainsKey(DDId);
        }

        public bool Has(Predicate<DataType> Condition)
        {
            return Container.Any((Pair) => Condition.Invoke(Pair.Value));
        }

        public Dictionary<int, DataType> Get(Predicate<DataType> Condition)
        {
            return Container
                    .Where((Pair) => Condition.Invoke(Pair.Value))
                    .Select((Pair) => Pair.Value)
                    .ToDictionary((Value) => Value.DDId);        
        }
    }


    
    public abstract class BaseJsonData<DataType> : BaseData<DataType> where DataType : BaseJsonData<DataType>
    {
    }

}

