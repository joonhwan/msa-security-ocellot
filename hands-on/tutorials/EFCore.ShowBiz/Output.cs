using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ShowBiz
{
    public static class Output 
    {
        // [ModuleInitializer] // C#9 Feature :-( 
        public static void SetCulture()
        {
            // get the $$$ showing up properly
            CultureInfo.CurrentCulture = 
                CultureInfo.CurrentUICulture = 
                    CultureInfo.GetCultureInfo("en-US");
        }
        
        public static Table AddRows<T>(
            this Table table,
            IEnumerable<T> values, params Func<T, object>[] columnFunc)
        {
            foreach (var value in values)
            {
                var columns = new List<string>();
                foreach (var func in columnFunc)
                {
                    columns.Add(func(value)?.ToString());
                }
                table.AddRow((string []) columns.ToArray());
            }
            
            return table;
        }

        public static void Results<T>(
            IEnumerable<T> query,
            string title,
            IRenderable results)
        {
            AnsiConsole.Render(
                new Panel(
                        new Grid()
                            .AddColumn()
                            .AddRow()
                            // TODO ToQueryString() for 3.1 ?    
                            // .AddRow($"[skyblue1]{query.ToQueryString()}[/]")
                            // .AddRow()
                            .AddRow(results)
                    )
                    .Header(title)
                    .BorderColor(Color.Yellow3)
                    .RoundedBorder()
            );
        }
    }
}