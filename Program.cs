using System;
using Sample05.Controller;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SqlController sqlController = new SqlController();

            //sqlController.test_insert();
            //sqlController.test_mult_insert();

            //sqlController.test_del();
            //sqlController.test_mult_del();

            //sqlController.test_insert();
            //sqlController.test_mult_insert();

            //sqlController.test_update();
            //sqlController.test_mult_update();

            //sqlController.test_select_one();
            //sqlController.test_select_list();

            sqlController.test_select_content_with_comment();
        }
    }
}
