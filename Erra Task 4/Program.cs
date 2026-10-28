namespace Erra_Task_4
{
    class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SavingsAccount : Account
    {
        public SavingsAccount()
        {
            
        }
        public SavingsAccount(string name)
        {
            Name = name;
        }
        public SavingsAccount(string name , double balance )
        {
            Name = name;
            Balance = balance;
        }
        public SavingsAccount(string name, double balance, double interestRate)
        {
            Name = name;
            Balance = balance;
            InterestRate = interestRate;
        }

        public double InterestRate { get; set; }

    }

    class CheckingAccount : Account
    {
        public bool Withdraw(double amount , double fee = 1.5)
        {
            if (Balance - (amount + fee) >= 0)
            {
                Balance -= (amount + fee);
                return true;
            }
            else
            {
                return false;
            }
        }
        public CheckingAccount()
        {

        }
        public CheckingAccount(string name)
        {
            Name = name;
            
        }
        public CheckingAccount(string name , double balance)
        {
            Name = name;
            Balance = balance;
        }
       
    }

    class TrustAccount : Account
    {
        public bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else if (amount > 5000)
            {
                Balance += (amount+50);
                return true;
            }
            else
            {

                Balance += amount;
                return true;
            }
            
        }

        public bool Withdraw(double amount)
        {
            if (Balance - amount >= 0 && amount <= Balance/5)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }

        }

        public TrustAccount(string name)
        {
            Name = name;
        }
        public TrustAccount(string name , double balance)
        {
            Name = name;
            Balance = balance;
        }
        public TrustAccount()
        {

        }
        public TrustAccount(string name, double balance, double fee)
        {
            Name = name;
            Balance = balance;
        }

    }





    // =================================================================================


    public static class AccountUtil
    {
        // Utility helper functions for Account class


        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for SavingsAccount
        public static void DepositSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Savings Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Savings Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for CheckingAccount
        public static void DepositChecking(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Checking Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawChecking(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Checking Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for TrustAccount
        public static void DepositTrust(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Trust Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawTrust(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Trust Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }






    // ==================================================================================
    internal class Program
{
    static void Main(string[] args)
    {
        // Accounts
        var accounts = new List<Account>();
        accounts.Add(new Account());
        accounts.Add(new Account("Larry"));
        accounts.Add(new Account("Moe", 2000));
        accounts.Add(new Account("Curly", 5000));

        AccountUtil.Deposit(accounts, 1000);
        AccountUtil.Withdraw(accounts, 2000);

        // Savings
        var savAccounts = new List<SavingsAccount>();
        savAccounts.Add(new SavingsAccount());
        savAccounts.Add(new SavingsAccount("Superman"));
        savAccounts.Add(new SavingsAccount("Batman", 2000));
        savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

        AccountUtil.DepositSavings(savAccounts, 1000);
        AccountUtil.WithdrawSavings(savAccounts, 2000);

        // Checking
        var checAccounts = new List<CheckingAccount>();
        checAccounts.Add(new CheckingAccount());
        checAccounts.Add(new CheckingAccount("Larry2"));
        checAccounts.Add(new CheckingAccount("Moe2", 2000));
        checAccounts.Add(new CheckingAccount("Curly2", 5000));

        AccountUtil.DepositChecking(checAccounts, 1000);
        AccountUtil.WithdrawChecking(checAccounts, 2000);
        AccountUtil.WithdrawChecking(checAccounts, 2000);

        // Trust
        var trustAccounts = new List<TrustAccount>();
        trustAccounts.Add(new TrustAccount());
        trustAccounts.Add(new TrustAccount("Superman2"));
        trustAccounts.Add(new TrustAccount("Batman2", 2000));
        trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

        AccountUtil.DepositTrust(trustAccounts, 1000);
        AccountUtil.DepositTrust(trustAccounts, 6000);
        AccountUtil.WithdrawTrust(trustAccounts, 2000);
        AccountUtil.WithdrawTrust(trustAccounts, 3000);
        AccountUtil.WithdrawTrust(trustAccounts, 500);

        Console.WriteLine();
    }
}

}


