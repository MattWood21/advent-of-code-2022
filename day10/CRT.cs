using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day10
{
    public class CRT
    {
        private List<List<char>> _crtBoard;

        public CRT()
        {
            var rows = new List<List<char>>(6);
            
            for(int i = 0; i < 6; i++)
            {
                var columns = new List<char>(40);
                for(int j = 0; j < 40; j++)
                {
                    columns.Add('?');
                }
                rows.Add(columns);
            }

            _crtBoard = rows;
        }

        public void Process(int cycle, int spritePosition)
        {
            var row = (cycle - 1) / 40;
            var column = (cycle - 1) % 40;
            var symbol = '.';
            if(column >= spritePosition - 1 && column <= spritePosition + 1)
            {
                symbol = '#';
            }
            _crtBoard[row][column] = symbol;
        }

        public string Draw()
        {
            var sb = new StringBuilder();
            foreach(var row in _crtBoard)
            {
                sb.AppendLine(new string(row.ToArray()));
            }
            return sb.ToString();
        }
    }
}
