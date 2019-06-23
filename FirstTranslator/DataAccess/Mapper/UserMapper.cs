using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    class UserMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_UserName = "UserName";
        private const string DB_COL_Password = "Password";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CREATE_USER_PR" };

            var u = (Entities_POJO.User)entity;
            operation.AddVarcharParam(DB_COL_UserName, u.UserName);
            operation.AddVarcharParam(DB_COL_Password, u.Password);

            return operation;

        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_PR" };

            var u = (User)entity;
            operation.AddVarcharParam(DB_COL_UserName, u.UserName);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USERS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USER_PR" };

            var u = (User)entity;
            operation.AddVarcharParam(DB_COL_UserName, u.UserName);
            operation.AddVarcharParam(DB_COL_Password, u.Password);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var u = (User)entity;
            operation.AddVarcharParam(DB_COL_UserName, u.UserName);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new User
            {
                UserName = GetStringValue(row, DB_COL_UserName),
                Password = GetStringValue(row, DB_COL_Password),

            };

            return user;

        }
    }
}
