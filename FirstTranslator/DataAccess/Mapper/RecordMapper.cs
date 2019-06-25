using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    class RecordMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_GUID = "GUID";
        private const string DB_COL_DATE = "Date";
        private const string DB_COL_Source = "Source";
        private const string DB_COL_Target = "Target";
        private const string DB_COL_OriginalPhrase = "OriginalPhrase";
        private const string DB_COL_Translation = "Translation";
        private const string DB_COL_Popularity = "Popularity";
        private const string DB_COL_User = "User";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CREATE_RECORD_PR" };

            var r = (Record)entity;
            operation.AddVarcharParam(DB_COL_GUID, r.GUID);
            operation.AddVarcharParam(DB_COL_DATE, r.Date);
            operation.AddVarcharParam(DB_COL_Source, r.Source);
            operation.AddVarcharParam(DB_COL_Target, r.Target);
            operation.AddVarcharParam(DB_COL_OriginalPhrase, r.OriginalPhrase);
            operation.AddVarcharParam(DB_COL_Translation, r.Translation);
            operation.AddIntParam(DB_COL_Popularity, r.Popularity);
            operation.AddVarcharParam(DB_COL_User, r.User);
        
            return operation;
        }


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_RECORDS_PR" };
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var word = BuildObject(row);
                lstResults.Add(word);
            }

            return lstResults;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var record = new Record
            {

                GUID = GetStringValue(row, DB_COL_GUID),
                Date = GetStringValue(row, DB_COL_DATE),
                Source = GetStringValue(row, DB_COL_Source),
                Target = GetStringValue(row, DB_COL_Target),
                OriginalPhrase = GetStringValue(row, DB_COL_OriginalPhrase),
                Popularity = GetIntValue(row, DB_COL_Popularity),
                Translation = GetStringValue(row, DB_COL_Translation),
                User = GetStringValue(row, DB_COL_User)

            };

            return record;

        }



        SqlOperation ISqlStaments.GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }



        SqlOperation ISqlStaments.GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStaments.GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
