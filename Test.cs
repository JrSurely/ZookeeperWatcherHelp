using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooKeeperNet;

namespace ZooKeeperClient
{
    public class ZookeeeperWatchTest
    {
        public void Test()
        {
            ZooKeeper zk = new ZooKeeper("172.16.22.171:2181", new TimeSpan(0, 0, 0, 300), null);

            ZookeeperWatcherHelp.Register(zk, "/root", (@event, nodeData) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@event.Path);
                Console.WriteLine(@event.Type.ToString());
                Console.WriteLine(@event.State.ToString());

                if (nodeData != null)
                    Console.WriteLine(System.Text.Encoding.Default.GetString(nodeData));

                Console.ForegroundColor = ConsoleColor.Gray;
            }, (@event, childrennode) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@event.Path);
                Console.WriteLine(@event.Type.ToString());
                Console.WriteLine(@event.State.ToString());

                if (childrennode != null)
                    Console.WriteLine("--" + string.Join("-", childrennode));

                Console.ForegroundColor = ConsoleColor.Gray;
            });



            ZookeeperWatcherHelp.Register(zk, "/root/test", (@event, nodeData) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@event.Path);
                Console.WriteLine(@event.Type.ToString());
                Console.WriteLine(@event.State.ToString());

                if (nodeData != null)
                    Console.WriteLine(System.Text.Encoding.Default.GetString(nodeData));

                Console.ForegroundColor = ConsoleColor.Gray;
            }, (@event, childrennode) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@event.Path);
                Console.WriteLine(@event.Type.ToString());
                Console.WriteLine(@event.State.ToString());

                if (childrennode != null)
                    Console.WriteLine("--" + string.Join("-", childrennode));

                Console.ForegroundColor = ConsoleColor.Gray;
            });
        }
    }
}
