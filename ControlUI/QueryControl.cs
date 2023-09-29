using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ControlUI
{
    public partial class QueryControl : UserControl
    {
        public QueryControl()
        {
            InitializeComponent();
        }

        private void QueryControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Full Blue Set and Wep And acc - char 
        {
            var nameChar = txtchar.Text;
            using (DotNet.VSRO_SHARDEntities db = new DotNet.VSRO_SHARDEntities())
            {
                var ReturnData = db.Database.SqlQuery<int>(@"
    DECLARE @CharID INT = (select top 1 CharID from _Char where CharName16 = @p0);
if (@CharID is not NULL)
begin
    exec dbo._SetFullBlueToChar @CharID , 'set' 
    exec dbo._SetFullBlueToChar @CharID , 'wep' 
    exec dbo._SetFullBlueToChar @CharID , 'acc'
    select 1;
    return;
end;
select 0;
", nameChar).FirstOrDefault();

                if (ReturnData == 1)
                {

                }




            }
        }
    }
}
