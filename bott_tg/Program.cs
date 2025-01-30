using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MyTelegramBot
{
    class Program
    {
        static string[] MainReq;
        static string[] Mcode;
        static string[] AssemblerCode;


        private static void Main(string[] args)
        {
            setRequres();
            
            Host tgbot = new Host("8028617076:AAE01yIw5yiYK0fh2wsNInvQWsIb_BHySVU");
            tgbot.Start();
            tgbot.OnMessage += OnMessage;
            Console.ReadLine();
        }

        private static async void OnMessage(ITelegramBotClient client, Update update)
        {
            if (update.Message?.Text == "/start")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0, MainReq[0]);
            }
            else
            {
                string ans = update.Message?.Text;

                if (ans != null)
                {
                    ans = ans.ToUpper();
                    Console.WriteLine(ans);
                 
                    int index = Array.IndexOf(Mcode, ans);

                    if (index >= 0)
                    {
                        Console.WriteLine($"{ans} --> {AssemblerCode[index]}");
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0, ($"{ans} --> {AssemblerCode[index]}"));

                    }

                    else
                    {
                        index = Array.IndexOf(AssemblerCode, ans);
                        if (index >= 0)
                        {
                            Console.WriteLine($"{ans} --> {Mcode[index]}");
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0, ($"{ans} --> {Mcode[index]}"));
                        }
                        else
                        {
                            Console.WriteLine("Out of index");
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0, "Такой элемент не найден");
                        }

                    }

                }

                else
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0, "Запрос некорректен");
                }
            }
        }


        static void setRequres() {

            MainReq = new string[5];

            MainReq[0] = "Вас приветствует бот конвертор машинного кода в ассемблер и наоборот\nНа базе микропроцесора intel8080a\nКод ассемблера записывается в виде (без рамок): [Команда(Операнд1,Операнд2)]";
            
            
            Mcode = new string[] {"87", "80", "81", "82", "83", "84", "85", "86", "C6", "8F", "88", "89", "8F", "8B", "8C", "8D", "8E", "CE"
            , "A7", "A0", "A1", "A2", "A3", "A4", "A5", "A6", "E6", "CD", "CC", "C4", "F4", "FC", "DC", "D4", "EC", "E4", "2F", "3F"
            , "BF", "B8", "B9", "BA", "BB", "BC", "BD", "BE", "FE", "27", "09", "19", "29", "39", "3D", "05", "0D", "15", "1D", "25", "2D"
            , "35", "0B", "1B", "2B", "3B", "F3", "FB", "76", "DB", "3C", "04", "0C", "14", "1C", "24", "2C", "34", "03", "13", "23", "33"
            , "C3", "CA", "C2", "F2", "FA", "DA", "D2", "EA", "E2", "3A", "0A", "1A", "2A", "01", "21", "31", "7F", "78", "79", "7A", "7B"
            , "7C", "7D", "7E", "47", "40", "41", "42", "43", "44", "45", "46", "4F", "48", "49", "4A", "4B", "4C", "4D", "4E", "57", "50"
            , "51", "52", "53", "54", "55", "56", "5F", "58", "59", "5A", "5B", "5C", "5D", "5E", "67", "60", "61", "62", "63", "64", "65"
            , "66", "6F", "68", "69", "6A", "6B", "6C", "6D", "6E", "77", "70", "71", "72", "73", "74", "75", "3E", "06", "0E", "16"
            , "1E", "26", "2E", "36", "00", "B7", "B0", "B1", "B2", "B3", "B4", "B5", "B6", "F6", "D3", "E9", "C1", "D1", "E1", "F1"
            , "C5", "D5", "E5", "17", "1F", "07", "0F", "20", "C9", "C8", "C0", "F0", "F8", "D8", "D0", "E8", "E0", "C7", "CF", "D7"
            , "DF", "E7", "EF", "F7", "FF", "30", "F9", "22", "32", "02", "12", "37", "97", "90", "91", "92", "93", "94", "95", "96"
            , "D6", "9F", "98", "99", "9A", "9B", "9C", "9D", "9E", "DE", "EB", "E3", "AF", "A8", "A9", "AA", "AB", "AC", "AD", "AE"
            , "EE"};



            AssemblerCode = new string[] { "ADD(A)", "ADD(B)", "ADD(C)", "ADD(D)", "ADD(E)", "ADD(H)", "ADD(L)", "ADD(M)", "ADI(D8)", "ADC(A)", "ADC(B)", "ADC(C)", "ADC(D)"
            , "ADC(E)", "ADC(H)", "ADC(L)", "ADC(M)", "ACI(D8)", "ANA(A)", "ANA(B)", "ANA(C)", "ANA(D)", "ANA(E)", "ANA(H)", "ANA(L)", "ANA(M)", "ANI(D8)", "CALL(A16)", "CZ(A16)"
            , "CNZ(A16)", "CP(A16)", "CM(A16)", "CC(A16)", "CNC(A16)", "CPE(A16)", "CPO(A16)", "CMA", "CMC", "CMP(A)", "CMP(B)", "CMP(C)", "CMP(D)", "CMP(E)", "CMP(H)", "CMP(L)",
              "CMP(M)", "CPI(D8)", "DAA", "DAD(B)", "DAD(D)", "DAD(H)", "DAD(SP)", "DCR(A)", "DCR(B)", "DCR(C)", "DCR(D)", "DCR(E)", "DCR(H)", "DCR(L)", "DCR(M)", "DCX(B)"
              , "DCX(D)", "DCX(H)", "DC(SP)", "DI", "EI", "HLT", "IN(PP)", "INR(A)", "INR(B)", "INR(C)", "INR(D)", "INR(E)", "INR(H)", "INR(L)", "INR(M)", "INX(B)", "INX(D)"
              , "INX(H)", "INX(SP)", "JMP(A16)", "JZ(A16)", "JNZ(A16)", "JP(A16)", "JM(A16)", "JC(A16)", "JNC(A16)", "JPE(A16)", "(JPOA16)", "LDA(A16)", "LDAX(B)", "LDAX(D)"
              , "LHLD(A16)", "LXI(B,D16)", "LXI(H,D16)", "LXI(SP,D16)", "MOV(A,A)", "MOV(A,B)", "MOV(A,C)", "MOV(A,D)", "MOV(A,E)", "MOV(A,H)", "MOV(A,L)", "MOV(A,M)"
              , "MOV(B,A)", "MOV(B,B)", "MOV(B,C)" , "MOV(B,D)", "MOV(B,E)", "MOV(B,H)", "MOV(B,L)", "MOV(B,M)", "MOV(C,A)", "MOV(C,B)", "MOV(C,C)", "MOV(C,D)", "MOV(C,E)", "MOV(C,H)"
              , "MOV(C,L)", "MOV(C,M)", "MOV(D,A)", "MOV(D,B)", "MOV(D,C)", "MOV(D,D)", "MOV(D,E)", "MOV(D,H)", "MOV(D,L)", "MOV(D,M)", "MOV(E,A)", "MOV(E,B)", "MOV(E,C)", "MOV(E,D)"
              , "MOV(E,E)", "MOV(E,H)", "MOV(E,L)", "MOV(E,M)", "MOV(H,A)", "MOV(H,B)", "MOV(H,C)", "MOV(H,D)", "MOV(H,E)", "MOV(H,H)", "MOV(H,L)", "MOV(H,M)", "MOV(L,A)", "MOV(L,B)"
              , "MOV(L,C)", "MOV(L,D)", "MOV(L,E)", "MOV(L,H)", "MOV(L,L)", "MOV(L,M)", "MOV(M,A)", "MOV(M,B)", "MOV(M,C)", "MOV(M,D)", "MOV(M,E)", "MOV(M,H)", "MOV(M,L)", "MVI(A,D8)"
              , "MVI(B,D8)", "MVI(C,D8)", "MVI(D,D8)", "MVI(E,D8)", "MVI(H,D8)", "MVI(L,D8)", "MVI(M,D8)", "NOP", "ORA(A)", "ORA(B)", "ORA(C)", "ORA(D)", "ORA(E)", "ORA(H)", "ORA(L)"
              , "ORA(M)", "ORI(D8)", "OUT(PP)", "PCHL", "POP(B)", "POP(D)", "POP(H)", "PSW", "PUSH(B)", "PUSH(D)", "PUSH(H)", "PUSH(PSW)", "RAL", "RAR", "RLC", "RRC", "RIM", "RET"
              , "RZ", "RNZ", "RP", "RM", "RC", "RNC", "RPE", "RPO", "RST(1)", "RST(2)", "RST(3)", "RST(4)", "RST(5)", "RST(6)", "RST(7)", "SIM", "SPHL", "SHLD(A16)", "STA(A16)", "STAX(B)"
              , "STAX(D)", "STC", "SUB(A)", "SUB(B)", "SUB(C)", "SUB(D)", "SUB(E)", "SUB(H)", "SUB(L)", "SUB(M)", "SUI(D8)", "SBB(A)", "SBB(B)", "SBB(C)", "SBB(D)", "SBB(E)", "SBB(H)", "SBB(L)"
              , "SBB(M)", "SBI(D8)", "XCHG", "XTHL", "XRA(A)", "XRA(B)", "XRA(C)", "XRA(D)", "XRA(E)", "XRA(H)", "XRA(L)", "XRA(M)", "XRI(D8)"};


        }


    }
}
