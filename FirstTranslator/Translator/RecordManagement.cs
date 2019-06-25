using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class RecordManagement
    {

        private RecordCrudFactory crudRecord;

        public RecordManagement()
        {
            crudRecord = new RecordCrudFactory();
        }

        public void Create(Record record)
        {
            crudRecord.Create(record);
        }

        public List<Record> RetrieveAll()
        {
            return crudRecord.RetrieveAll<Record>();
        }
    }
}
