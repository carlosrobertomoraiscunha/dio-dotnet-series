using System;
using DIO.Series.Entities;
using DIO.Series.Menu;
using DIO.Series.Repository;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            ConsoleKeyInfo pressedKey;

            PrintMenu();

            do
            {
                pressedKey = Console.ReadKey(true);

                if (int.TryParse(pressedKey.KeyChar.ToString(), out int result))
                {
                    if (Enum.TryParse(typeof(MenuOptions), result.ToString(), out object option))
                    {
                        SelectOption((MenuOptions)option);
                    }
                }
            } while (pressedKey.Key != ConsoleKey.Escape);
        }

        private static void SelectOption(MenuOptions option)
        {
            Console.Clear();
            Console.CursorVisible = true;

            switch (option)
            {
                case MenuOptions.Listar:
                    ListAllSeries();
                    break;
                case MenuOptions.Inserir:
                    CreateNewSerie();
                    break;
                case MenuOptions.Atualizar:
                    UpdateSerie();
                    break;
                case MenuOptions.Excluir:
                    DeleteSerie();
                    break;
                case MenuOptions.Visualizar:
                    ViewSerieDetails();
                    break;
            }

            Console.WriteLine();
            Console.Write("Aperte qualquer tecla para continuar!");
            Console.ReadKey(true);
            Console.Clear();

            PrintMenu();
        }

        private static void ViewSerieDetails()
        {
            Console.Write("Digite o id da série a ser visualizada: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repository.GetById(id);

            Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série a ser deletada: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write($"Tem certeza que deseja deletar a série {repository.GetById(id).Title}? Y/Any");
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            if (pressedKey.Key == ConsoleKey.Y)
            {
                repository.Delete(id);

                Console.WriteLine();
                Console.WriteLine("Série deletada com sucesso!");
            }
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série a ser atualizada: ");
            int id = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string overview = Console.ReadLine();

            SerieEntity updatedSerie = new SerieEntity(id: id,
                                                        genre: (Genre)genre,
                                                        title: title,
                                                        year: year,
                                                        overview: overview);

            repository.Update(id, updatedSerie);

            Console.WriteLine();
            Console.Write("Série atualizada com sucesso!");
        }

        private static void CreateNewSerie()
        {
            Console.WriteLine("Cadastrar Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string overview = Console.ReadLine();

            SerieEntity newSerie = new SerieEntity(id: repository.GetNextId(),
                                                    genre: (Genre)genre,
                                                    title: title,
                                                    year: year,
                                                    overview: overview);

            repository.Create(newSerie);

            Console.WriteLine();
            Console.Write("Série cadastrada com sucesso!");
        }

        private static void ListAllSeries()
        {
            Console.WriteLine("Lista de Séries");
            Console.WriteLine();

            var serieList = repository.ListAll();

            if (serieList.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
            }

            foreach (var serie in serieList)
            {
                Console.WriteLine($"#ID {serie.Id} - {serie.Title} {(serie.Active ? "" : "*Excluído*")}");
            }
        }

        private static void PrintMenu()
        {
            Console.CursorVisible = false;

            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            foreach (var serieOption in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine($"{(int)serieOption} - {serieOption} série");
            }

            Console.WriteLine("Esc - Sair");
        }
    }
}
