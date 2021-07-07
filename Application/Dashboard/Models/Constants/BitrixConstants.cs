namespace Monitor.Application.Dashboard.Models.Constants
{
    public static class BitrixConstants
    {
        public const string NotProcessed        = "NEW";                //Не обработан
        public const string InWork              = "13";                 //В работе
        public const string Selection           = "8";                  //Подбор
        public const string Expectation         = "PREPARATION";        //Ожидание
        public const string Processing          = "21";                 //Оформление
        public const string InTransit           = "22";                 //В пути
        public const string ReadyForExtradition = "1";                  //Готов к выдаче
        public const string RequestReturn       = "C1:NEW";             //Запрос на возврат ===
        public const string PreparingToShip     = "FINAL_INVOICE";      //Готов к отгрузке
        public const string DealIsSuccessful    = "WON";                //Сделка успешна
        public const string Test                = "LOSE";               //Отменен по причине тест
        public const string Double              = "3";                  //Отменен по причине дубль

        public const string AutoReturn          = "C1:EXECUTING";       //Автовозврат
        public const string PartsReturn         = "14";                 //Частичный возврат
        public const string Return              = "10";                 //Возврат
        public const string AutoReturnSTO_1     = "17";                 //Автовозврат СТО
        public const string PartsReturnSTO_1    = "18";                 //Частичный возврат СТО
        public const string ReturnSTO           = "19";                 //Возврат СТО
        public const string ReturnProduct       = "C1:1";               //Возврат товара===
        public const string PartsReturnProduct  = "C1:FINAL_INVOICE";   //Частичный возврат===
        public const string AutoReturnSTO_2     = "C1:3";               //Автовозвраты СТО
        public const string ReturnProductSTO    = "C1:2";               //Возврат товара СТО===
        public const string PartsReturnSTO_2    = "C1:4";               //Частичный возврат СТО===
        public const string ReturnSucces        = "C1:WON";             //Возврат успешен===

        public const string RequestReturn_2     = "16";                 //Запрос на возврат
        public const string AutoRequestReturn   = "6";                  //Автовозврат

        public const string NotRequest          = "23";                 //Нет ответа
        public const string WaitingPay          = "EXECUTING";          //Нет ответа
    }
}
