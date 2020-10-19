using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\WorkWithFiles\data.txt";
            string newpath = @"D:\WorkWithFiles\newdata.txt";
            ArrayList data = new ArrayList();
            List<Client> clients = new List<Client>();
            List<string> maindata = new List<string>();
            List<string> newdata = new List<string>();
            string temp;
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    while ((temp = sr.ReadLine()) != null)
                    {
                        data.Add(temp);
                    }
                }

                foreach (string d in data)
                {
                    string[] DataList = d.Split("; ");
                    for (int i = 0; i < DataList.Length; i++)
                    {
                        maindata.Add(DataList[i]);
                    }
                }
                int count2 = 0;
                for (int i = 0; i < maindata.Count / 3; i++)
                {
                    clients.Add(new Client());
                }
                for (int count = 0; count < clients.Count; count++)
                {
                    clients[count].id = maindata[count2];
                    clients[count].passportnumber = maindata[count2 + 1];
                    clients[count].payment = maindata[count2 + 2];
                    count2 += 3;
                }
                foreach (Client c in clients)
                {
                    c.ShowData();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Какую строчку вы хотите изменить?");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < clients.Count)
            {
                Console.WriteLine("Что вы хотите изменить: \n1.ID \n2.Passport number\n3.Payment\nВыберите номер перед пунктом меню для перехода.");
                int num2 = Convert.ToInt32(Console.ReadLine());
                switch (num2)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите новый ID.");
                            string ins = Console.ReadLine();
                            clients[num].id = ins;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите новый Passport Number.");
                            string ins = Console.ReadLine();
                            clients[num].passportnumber = ins;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите новый Payment.");
                            string ins = Console.ReadLine();
                            clients[num].payment= ins;
                            break;
                        }
                }
                
                using (StreamWriter sw = File.CreateText(newpath))
                {
                    foreach (Client c in clients)
                    {
                        sw.WriteLine($"{c.id}; {c.passportnumber};{c.payment}");
                    }
                }

            }
            Console.ReadKey();
        }

        class Client
        {
            public string id { get; set; }
            public string passportnumber { get; set; }

            public string payment { get; set; }

            public Client()
            {

            }
            public void ShowData()
            {
                Console.WriteLine($"ID: {id}, passport number: {passportnumber}, payment: {payment}.");
            }
        }
    }
}
