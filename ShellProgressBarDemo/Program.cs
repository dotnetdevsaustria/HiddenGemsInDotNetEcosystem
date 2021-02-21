using System;
using System.Threading.Tasks;
using ShellProgressBar;

namespace ShellProgressBarDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int totalTicks = 10;

            using var pbar = new ProgressBar(totalTicks, "Initial message", new ProgressBarOptions
            {
                ProgressCharacter = '─',
                ProgressBarOnBottom = true
            });
            
            await RunProgressBar(pbar);

            Console.WriteLine("Start next progress bar");
            Console.ReadLine();

            using var pbar2 = new ProgressBar(totalTicks, "showing off styling", new ProgressBarOptions
            {
                ForegroundColor = ConsoleColor.Yellow,
                ForegroundColorDone = ConsoleColor.DarkGreen,
                BackgroundColor = ConsoleColor.DarkGray,
                BackgroundCharacter = '\u2593'
            });

            await RunProgressBar(pbar2);
        }

        private static async Task RunProgressBar(ProgressBar pbar)
        {
            for (int i = 0; i < pbar.MaxTicks; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));
                pbar.Tick();
            }
        }
    }
}
