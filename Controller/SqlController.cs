using Dapper;
using Sample05.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sample05.Controller
{
    public class SqlController
    {
        /// <summary>
        /// 测试插入单条数据
        /// </summary>
        public void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",

            };
            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量插入两条数据
        /// </summary>
        public void test_mult_insert()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            },
               new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            },
        };

            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试删除单条数据
        /// </summary>
        public void test_del()
        {
            var content = new Content
            {
                id = 5,

            };
            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量删除两条数据
        /// </summary>
        public void test_mult_del()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=6,

            },
               new Content
            {
                id=7,

            },
        };

            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试修改单条数据
        /// </summary>
        public void test_update()
        {
            var content = new Content
            {
                id = 8,
                title = "标题8",
                content = "内容8",

            };
            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量修改多条数据
        /// </summary>
        public void test_mult_update()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=9,
                title = "批量修改标题9",
                content = "批量修改内容9",

            },
               new Content
            {
                id =10,
                title = "批量修改标题10",
                content = "批量修改内容10",

            },
        };

            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_update：修改了{result}条数据！");
            }
        }


        /// <summary>
        /// 查询单条指定的数据
        /// </summary>
        public void test_select_one()
        {
            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"select * from [dbo].[content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_insert, new { id = 8 });
                Console.WriteLine($"test_select_one：查到的数据为：");
            }
        }

        /// <summary>
        /// 查询多条指定的数据
        /// </summary>
        public void test_select_list()
        {
            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"select * from [dbo].[content] where id in @ids";
                var result = conn.Query<Content>(sql_insert, new { ids = new int[] { 9, 10 } });
                Console.WriteLine($"test_select_one：查到的数据为：");
            }
        }

        /// <summary>
        /// 查询id为8的文章，文章是包含评论列表的
        /// </summary>
        public void test_select_content_with_comment()
        {
            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql_insert = @"select * from content where id=@id;
select * from comment where content_id=@id;";
                using (var result = conn.QueryMultiple(sql_insert, new { id = 8 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:内容8的评论数量为{content.comments.Count()}");
                }

            }
        }
    }
}
