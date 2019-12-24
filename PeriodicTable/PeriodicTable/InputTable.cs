using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PeriodicTable
{
    class InputTable
    {
        //initial table stores all basic explosives found in the Internet
        //in addition, it can be used to reset Table.txt
        private StringBuilder InitialTable;

        //file "Table.txt" is the one we work with
        private string TableName;
        public InputTable(string tableName)
        {
            //because I can
            InitialTable = new StringBuilder(
                                            "Алюминий\tAl\n" +
                                            "Аммония карбонат\t(NH4)2CO3\n" +
                                            "Аммония нитрат\tNH4NO3\n" +
                                            "Аммония перхлорат\tNH4ClO4\n" +
                                            "Аммония пикрат\tNH4C6H2(NO2)3O\n" +
                                            "Аммония сульфат\t(NH4)2SO4\n" +
                                            "Аммония хлорид\tNH4Cl\n" +
                                            "Антрацен\tC14H10\n" +
                                            "Бария нитрат\tBa(NO3)2\n" +
                                            "Бария хлорат\tBa(ClO3)2H2O\n" +
                                            "Бария хромат\tBaCrO4\n" +
                                            "Бария перекись\tBaO2\n" +
                                            "Бария силицид\tBaSi2\n" +
                                            "Бумага\t-1.3\n" +
                                            "Вазелин\tC18H38\n" +
                                            "Глицерин\tC3H5(OH)3\n" +
                                            "Глюкоза\tC6H12O6\n" +
                                            "Гремучая ртуть\tHg(ONC)2\n" +
                                            "Декстрин\tC6H10O5\n" +
                                            "Динитробензол\tC6H4(NO2)2\n" +
                                            "Динитроглицерин\tC3H5(ONO2)2OH\n" +
                                            "Динитроксилол\tC6H2(NO2)2(CH3)2\n" +
                                            "Динитронафталин\tC10H6(NO2)2\n" +
                                            "Динитрохлоргидрин\tC3H5(ONO2)2Cl\n" +
                                            "Динитрофенол\tC6H3(NO2)2OH\n" +
                                            "Динитротолуол\tC6H3(NO2)2CH3\n" +
                                            "Дициандиамид\t(CN)2(NH2)2\n" +
                                            "Калия бихромат\tK2Cr2O7\n" +
                                            "Калия нитрат\tKNO3\n" +
                                            "Калия хлорат\tKClO3\n" +
                                            "Калия перхлорат\tKClO4\n" +
                                            "Калия пикрат\tC6H2(NO2)3OK\n" +
                                            "Кальция нитрат\tCa(NO3)2H8O4\n" +
                                            "Кальция перхлорат\tCa(ClO4)2\n" +
                                            "Кальция хлорат\tCa(ClO3)2\n" +
                                            "Кальция силицид\tCaSi2\n" +
                                            "Камфора\tC10H16O\n" +
                                            "Керосин\t-3.43\n" +
                                            "Клетчатка\tC6H10O5\n" +
                                            "Крахмал\tC6H10O5\n" +
                                            "Маннит\tC6H8(OH)6\n" +
                                            "Мононитроглицерин\tC3H5(ONO2)(OH)2\n" +
                                            "Мононитроглицерин\tC10H7NO2\n" +
                                            "Мононитрохлоргидрин\tC3H5(ONO2)OHCl\n" +
                                            "Мононитротолуол\tC6H4(NO2)CH3\n" +
                                            "Мононитрофенол\tC6H4(NO2)OH\n" +
                                            "Мука злаков\tC15H25O11\n" +
                                            "Мука древесная(очищ.)\tC15H22O10\n" +
                                            "Мука древесная(опилки)\t-1.35\n" +
                                            "Масло(растительное)\tC23H36O7\n" +
                                            "Натрия нитрат\tNaNO3\n" +
                                            "Натрия хлорат\tNaClO3\n" +
                                            "Натрия перхлорат\tNaClO4\n" +
                                            "Натрия пикрат\tC6H2(NO2)3ONa\n" +
                                            "Нафталин\tC10H8\n" +
                                            "Нитробензол\tC6H5NO2\n" +
                                            "Нитроглицерин\tC3H5(ONO2)3\n" +
                                            "Нитрогуанидин\tC(NH2)2NNO2\n" +
                                            "Нитроклетчатка(коллоксилин)\tC24H31N9O38\n" +
                                            "Нитроклетчатка(пироксилин)\tC24H29N11O42\n" +
                                            //"Нитрокрахмал\t-0.335\n" +
                                            "Нитроманнит\tC6H8(NO3)6\n" +
                                            "Парафин\tC24H50\n" +
                                            "Пикриновая кислота\tC6H2(NO2)3OH\n" +
                                            "Сахар(тростниковый)\tC12H22O11\n" +
                                            "Сера\tS\n" +
                                            "Свинца нитрат\tPb(NO3)2\n" +
                                            "Скипидар\tC10H16\n" +
                                            "Стронция нитрат\tSr(NO3)2\n" +
                                            "Сурьма сернистая\tSb2S3\n" +
                                            "Сурьма металлическая\tSb\n" +
                                            "Таннин\tC14H10O9\n" +
                                            "Тетранитроанилин\tC6H(NH2)(NO2)4\n" +
                                            "Тетранитродиглицерин\t(C3H5)2O(NO3)4\n" +
                                            "Тетранитродиметиланилин\tC6H(NO2)3N(CH3)2\n" +
                                            "Тетранитрометан\tC(NO2)4\n" +
                                            "Теранитрометиланилин\tC6H2(NO2)4NCH3\n" +
                                            "Тетранитронафталин\tC10H4(NO2)4\n" +
                                            "Тринитроанилин\tC6H2(NO2)3NH2\n" +
                                            "Тринитробензол\tC6H3(NO2)3\n" +
                                            "Тринитродиметиланилин\tC6H2(NO2)3N(CH3)2\n" +
                                            "Тринитрокрезол\tC6HCH3(NO2)3OH\n" +
                                            "Тринитронафталин\tC10H5(NO2)3\n" +
                                            "Тринитрорезорцин\tC6H(NO2)3(OH)2\n" +
                                            "Тринитротолуол\tC6H2(NO2)3CH3\n" +
                                            "Уголь\tC\n" +
                                            "Фенол\tC6H5OH\n"
                                            );

            TableName = tableName;
            //if there's no Table.txt we create it and fill with InitialTable
            if (!File.Exists(TableName))
            {
                using (StreamWriter sw = new StreamWriter(TableName, false))
                {
                    sw.WriteLine(InitialTable);
                }

            }
        }
    }
}
