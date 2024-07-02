using System;
using System.Collections.Generic;



namespace Lagerverwaltung_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articleList = new List<Article>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Was möchten Sie machen? Drücken Sie die entsprechende Zahl:");
                Console.WriteLine("1 = Artikel Hinzufügen");
                Console.WriteLine("2 = Einbuchen");
                Console.WriteLine("3 = Ausbuchen");
                Console.WriteLine("4 = Bestandesmenge anzeigen");
                Console.WriteLine("5 = Lagerinhalt verschieben");
                Console.WriteLine("6 = Artikelnummer suchen");
                Console.WriteLine("7 = Beenden");
                Console.WriteLine("");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine gültige Option.");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddArticle(articleList);
                        break;
                    case 2:
                        BookInArticle(articleList);
                        break;
                    case 3:
                        BookOutArticle(articleList);
                        break;
                    case 4:
                        ShowStock(articleList);
                        break;
                    case 5:
                        MoveArticle(articleList);
                        break;
                    case 6:
                        SearchArticle(articleList);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine gültige Option.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Methode zum Suchen eines Artikels nach Artikelnummer
        static void SearchArticle(List<Article> articleList)
        {
            Console.Clear();
            Console.Write("Geben Sie die Artikelnummer ein: ");
            int articleNumberToFind;
            if (int.TryParse(Console.ReadLine(), out articleNumberToFind))
            {
                Article foundArticle = articleList.Find(article => article.ArticleNumber == articleNumberToFind);
                if (foundArticle != null)
                {
                    Console.WriteLine($"Gefundener Artikel - Artikelnummer: {foundArticle.ArticleNumber}, Name: {foundArticle.Name}, Preis: {foundArticle.Price:C}, Meter: {foundArticle.Meter}, Liter: {foundArticle.Liter}, LieferantenID: {foundArticle.DelivererID}");
                    Console.WriteLine("Lagerplätze:");
                    foreach (var warehouse in foundArticle.Warehouses)
                    {
                        Console.WriteLine($"Lagerplatz: {warehouse.Key}, Menge: {warehouse.Value}");
                    }
                }
                else
                {
                    Console.WriteLine($"Artikel mit Artikelnummer {articleNumberToFind} konnte leider nicht gefunden werden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Artikelnummer ein.");
            }
            Console.ReadLine();
        }

        // Methode zum Einbuchen eines Artikels
        static void BookInArticle(List<Article> articleList)
        {
            Console.Clear();
            Console.Write("Geben Sie die Artikelnummer ein: ");
            int articleNumberToBookIn;
            if (int.TryParse(Console.ReadLine(), out articleNumberToBookIn))
            {
                Article articleToBookIn = articleList.Find(article => article.ArticleNumber == articleNumberToBookIn);
                if (articleToBookIn != null)
                {
                    Console.Write("Geben Sie die Menge zum Einbuchen ein: ");
                    int quantityToBookIn;
                    if (int.TryParse(Console.ReadLine(), out quantityToBookIn))
                    {
                        articleToBookIn.Quantity += quantityToBookIn;
                        Console.WriteLine($"{quantityToBookIn} Stück(e) von Artikel {articleToBookIn.Name} wurden erfolgreich eingebucht.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Menge ein.");
                    }
                }
                else
                {
                    Console.WriteLine($"Artikel mit Artikelnummer {articleNumberToBookIn} konnte leider nicht gefunden werden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Artikelnummer ein.");
            }
            Console.ReadLine();
        }

        // Methode zum Ausbuchen eines Artikels
        static void BookOutArticle(List<Article> articleList)
        {
            Console.Clear();
            Console.Write("Geben Sie die Artikelnummer ein: ");
            int articleNumberToBookOut;
            if (int.TryParse(Console.ReadLine(), out articleNumberToBookOut))
            {
                Article articleToBookOut = articleList.Find(article => article.ArticleNumber == articleNumberToBookOut);
                if (articleToBookOut != null)
                {
                    Console.Write("Geben Sie die Menge zum Ausbuchen ein: ");
                    int quantityToBookOut;
                    if (int.TryParse(Console.ReadLine(), out quantityToBookOut))
                    {
                        if (articleToBookOut.Quantity >= quantityToBookOut)
                        {
                            articleToBookOut.Quantity -= quantityToBookOut;
                            Console.WriteLine($"{quantityToBookOut} Stück(e) von Artikel {articleToBookOut.Name} wurden erfolgreich ausgebucht.");
                        }
                        else
                        {
                            Console.WriteLine($"Nicht genügend Bestand von Artikel {articleToBookOut.Name} für diese Menge.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Menge ein.");
                    }
                }
                else
                {
                    Console.WriteLine($"Artikel mit Artikelnummer {articleNumberToBookOut} konnte leider nicht gefunden werden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Artikelnummer ein.");
            }
            Console.ReadLine();
        }

        // Methode zum Anzeigen des Lagerbestands
        static void ShowStock(List<Article> articleList)
        {
            Console.Clear();
            Console.WriteLine("Lagerbestand:");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| Artikelnummer | Name       | Bestand | LieferantenID |");
            Console.WriteLine("-----------------------------------------------------------");



            foreach (var article in articleList)
            {
                Console.WriteLine($"| {article.ArticleNumber,14} | {article.Name,-10} | {article.Quantity,7} | {article.DelivererID,-13} |");
                Console.WriteLine("|---------------------------------------------------------|");
                Console.WriteLine("| Lagerplatz     | Menge     |");
                Console.WriteLine("|----------------|-----------|");



                foreach (var warehouse in article.Warehouses)
                {
                    Console.WriteLine($"| {warehouse.Key,-14} | {warehouse.Value,-9} |");
                }
                Console.WriteLine("|---------------------------------------------------------|\n");
            }
            Console.ReadLine();
        }

        // Methode zum Verschieben eines Artikels zwischen Lagern
        static void MoveArticle(List<Article> articleList)
        {
            Console.Clear();
            Console.Write("Geben Sie die Artikelnummer ein, die verschoben werden soll: ");
            int articleNumberToMove;
            if (int.TryParse(Console.ReadLine(), out articleNumberToMove))
            {
                Article articleToMove = articleList.Find(article => article.ArticleNumber == articleNumberToMove);
                if (articleToMove != null)
                {
                    Console.Write("Geben Sie das Ziel-Lager ein: ");
                    string targetWarehouse = Console.ReadLine();
                    Console.Write("Geben Sie die Menge zum Verschieben ein: ");
                    int quantityToMove;
                    if (int.TryParse(Console.ReadLine(), out quantityToMove))
                    {
                        articleToMove.MoveToWarehouse(targetWarehouse, quantityToMove);
                        Console.WriteLine($"{quantityToMove} Stück(e) von Artikel {articleToMove.Name} wurden nach {targetWarehouse} verschoben.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Menge ein.");
                    }
                }
                else
                {
                    Console.WriteLine($"Artikel mit Artikelnummer {articleNumberToMove} konnte leider nicht gefunden werden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Artikelnummer ein.");
            }
            Console.ReadLine();
        }

        // Methode zum Hinzufügen eines neuen Artikels
        static void AddArticle(List<Article> articleList)
        {
            Console.Clear();
            Console.Write("Geben Sie die Artikelnummer ein: ");
            int articleNumber;
            if (!int.TryParse(Console.ReadLine(), out articleNumber))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Artikelnummer ein.");
                Console.ReadLine();
                return;
            }

            Console.Write("Geben Sie den Artikelnamen ein: ");
            string name = Console.ReadLine();

            Console.Write("Geben Sie den Preis ein: ");
            double price;
            if (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie einen gültigen Preis ein.");
                Console.ReadLine();
                return;
            }

            Console.Write("Geben Sie die Menge in Stück ein: ");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Menge ein.");
                Console.ReadLine();
                return;
            }

            Console.Write("Geben Sie die Länge in Metern ein (0, wenn nicht zutreffend): ");
            double meter;
            if (!double.TryParse(Console.ReadLine(), out meter))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Länge ein oder 0, falls nicht zutreffend.");
                Console.ReadLine();
                return;
            }

            Console.Write("Geben Sie das Volumen in Litern ein (0, wenn nicht zutreffend): ");
            double liter;
            if (!double.TryParse(Console.ReadLine(), out liter))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie ein gültiges Volumen ein oder 0, falls nicht zutreffend.");
                Console.ReadLine();
                return;
            }

            Console.Write("Geben Sie die Lieferanten-ID ein: ");
            string delivererID = Console.ReadLine();

            Article newArticle = new Article(articleNumber, name, price, meter, liter);
            newArticle.Quantity = quantity;
            newArticle.DelivererID = delivererID;

            articleList.Add(newArticle);

            Console.WriteLine($"Artikel {name} wurde erfolgreich hinzugefügt.");
            Console.ReadLine();
        }
    }

    class Article
    {
        public int ArticleNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Meter { get; set; }
        public double Liter { get; set; }
        public Dictionary<string, int> Warehouses { get; set; }
        public string DelivererID { get; set; }

        public Article(int articleNumber, string name, double price, double meter, double liter)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Price = price;
            Quantity = 0;
            Meter = meter;
            Liter = liter;
            Warehouses = new Dictionary<string, int>();
            DelivererID = "";
        }

        public void MoveToWarehouse(string warehouse, int quantity)
        {
            if (Warehouses.ContainsKey(warehouse))
            {
                Warehouses[warehouse] += quantity;
            }
            else
            {
                Warehouses[warehouse] = quantity;
            }
            Quantity -= quantity;
        }
    }
}