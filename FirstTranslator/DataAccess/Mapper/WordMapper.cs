using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    class WordMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_GUID = "GUID";
        private const string DB_COL_TranslatedWord = "TranslatedWord";
        private const string DB_COL_Quantity = "Quantity";
        private const string DB_COL_Sorce = "Source";
        private const string DB_COL_Target = "Target";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CREATE_WORD_PR" };

            var w = (Word)entity;
            operation.AddVarcharParam(DB_COL_GUID, w.GUID);
            operation.AddVarcharParam(DB_COL_TranslatedWord, w.TranslatedWord);
            operation.AddIntParam(DB_COL_Quantity, w.Quantity);
            operation.AddVarcharParam(DB_COL_Sorce, w.Source);
            operation.AddVarcharParam(DB_COL_Target, w.Target);


            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_WORD_PR" };

            var w = (Word)entity;
            operation.AddVarcharParam(DB_COL_TranslatedWord, w.TranslatedWord);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_WORDS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_WORD_PR" };

            var w = (Word)entity;
            operation.AddVarcharParam(DB_COL_GUID, w.GUID);
            operation.AddVarcharParam(DB_COL_TranslatedWord, w.TranslatedWord);
            operation.AddIntParam(DB_COL_Quantity, w.Quantity);
            operation.AddVarcharParam(DB_COL_Sorce, w.Source);
            operation.AddVarcharParam(DB_COL_Target, w.Target);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_WORD_PR" };

            var w = (Word)entity;
            operation.AddVarcharParam(DB_COL_GUID, w.GUID);
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
            var word = new Word
            {
                GUID = GetStringValue(row, DB_COL_GUID),
                TranslatedWord = GetStringValue(row, DB_COL_TranslatedWord),
                Quantity = GetIntValue(row, DB_COL_Quantity)
            };

            return word;

        }
    }
}
