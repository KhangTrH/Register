using System;
using System.Collections.Generic;

class Program
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    static List<Account> accounts = new List<Account>(); 

    static void Register()
    {
        Console.WriteLine("Đăng ký tài khoản mới");
        Console.Write("Tên đăng nhập: ");
        string username = Console.ReadLine();
        Console.Write("Mật khẩu: ");
        string password = Console.ReadLine();

        // Kiểm tra xem tên đăng nhập đã tồn tại chưa
        if (accounts.Exists(acc => acc.Username == username))
        {
            Console.WriteLine("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.");
            return;
        }

        // Thêm tài khoản mới vào danh sách
        accounts.Add(new Account { Username = username, Password = password });
        Console.WriteLine("Đăng ký thành công!");
    }

    static void Login()
    {
        Console.WriteLine("Đăng nhập");
        Console.Write("Tên đăng nhập: ");
        string username = Console.ReadLine();
        Console.Write("Mật khẩu: ");
        string password = Console.ReadLine();

        // Kiểm tra xem tài khoản có tồn tại trong danh sách không
        Account account = accounts.Find(acc => acc.Username == username && acc.Password == password);
        if (account != null)
        {
            Console.WriteLine("Đăng nhập thành công!");
        }
        else
        {
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng.");
        }
    }
    static void ListAccounts()
    {
        Console.WriteLine("\nDanh sách các tài khoản đã đăng ký:");
        if (accounts.Count == 0)
        {
            Console.WriteLine("Không có tài khoản nào được đăng ký.");
            return;
        }

        foreach (var account in accounts)
        {
            Console.WriteLine($"Tên đăng nhập: {account.Username}");
        }
    }


    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChào mừng bạn đến với hệ thống");
            Console.WriteLine("1. Đăng ký");
            Console.WriteLine("2. Đăng nhập");
            Console.WriteLine("3. Danh sách tài khoản đã đăng ký");
            Console.WriteLine("4. Thoát");
            Console.Write("Vui lòng chọn: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    ListAccounts();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }
}
