﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_mvc_itstep_hometask_News_Site.Models.ViewModels
{
    public class NewsCategoriesVM
    {
        public List<(string, string, string)> newsCategories = new()
        {
            ("Все новости", "/news", "main-item"),
            ("Действующие лица", "/library/characters", "main-item"),
            ("Расследования", "/library/investigations", "main-item"),
            ("Бизнес", "/rubric/business", "main-item"),
            ("ТЭК", "/rubric/business/energy", ""),
            ("Промышленность", "/rubric/business/industry", ""),
            ("Транспорт", "/rubric/business/transport", ""),
            ("Агропром", "/rubric/business/agriculture", ""),
            ("Торговля и услуги", "/rubric/business/retail", ""),
            ("Спортивный бизнес", "/rubric/business/sport", ""),
            ("Экономика", "/rubric/economics", "main-item"),
            ("Макроэкономика", "/rubric/economics/macro", ""),
            ("Госинвестиции и проекты", "/rubric/economics/state_investments", ""),
            ("Мировая экономика", "/rubric/economics/global", ""),
            ("Налоги и сборы", "/rubric/economics/taxes", ""),
            ("Правила", "/rubric/economics/regulations", ""),
            ("Финансы", "/rubric/finance", "main-item"),
            ("Банки", "/rubric/finance/banks", ""),
            ("Рынки", "/rubric/finance/markets", ""),
            ("Профучастники", "/rubric/finance/players", ""),
            ("Страхование", "/rubric/finance/insurance", ""),
            ("Персональные финансы", "/rubric/finance/personal_finance", ""),
            ("Мнения", "/rubric/opinion", "main-item"),
            ("Детали", "/rubric/opinion/details", ""),
            ("Аналитика", "/rubric/opinion/analytics", ""),
            ("От редакции", "/rubric/opinion/editorial", ""),
            ("Политика", "/rubric/politics", "main-item"),
            ("Власть", "/rubric/politics/official", ""),
            ("Демократия", "/rubric/politics/democracy", ""),
            ("Международные отношения", "/rubric/politics/international", ""),
            ("Безопасность и право", "/rubric/politics/security_law", ""),
            ("Социальная политика", "/rubric/politics/social", ""),
            ("Международная жизнь", "/rubric/politics/foreign", ""),
            ("Технологии", "/rubric/technology", "main-item"),
            ("Телекоммуникации", "/rubric/technology/telecom", ""),
            ("Интернет и digital", "/rubric/technology/internet", ""),
            ("Медиа", "/rubric/technology/media", ""),
            ("ИТ-бизнес", "/rubric/technology/it_business", ""),
            ("Персональные технологии", "/rubric/technology/personal_technologies", ""),
            ("Недвижимость", "/rubric/realty", "main-item"),
            ("Жилая недвижимость", "/rubric/realty/housing", ""),
            ("Коммерческая недвижимость", "/rubric/realty/commercial_property", ""),
            ("Стройка и инфраструктура", "/rubric/realty/infrastructure", ""),
            ("Архитектура и дизайн", "/rubric/realty/architecture", ""),
            ("Место для жизни", "/rubric/realty/districts", ""),
            ("Авто", "/rubric/auto", "main-item"),
            ("Автомобильная промышленность", "/rubric/auto/auto_industry", ""),
            ("Легковые автомобили", "/rubric/auto/cars", ""),
            ("Коммерческие автомобили", "/rubric/auto/commercial_vehicles", ""),
            ("Дизайн и технологии", "/rubric/auto/car_design", ""),
            ("Тест-драйвы", "/rubric/auto/test_drive", ""),
            ("Менеджмент", "/rubric/management", "main-item"),
            ("Карьера", "/rubric/management/career", ""),
            ("Управление", "/rubric/management/management", ""),
            ("Зарплаты и занятость", "/rubric/management/compensation", ""),
            ("Предпринимательство", "/rubric/management/entrepreneurship", ""),
            ("Бизнес-образование", "/rubric/management/education", ""),
            ("Стиль жизни", "/rubric/lifestyle", "main-item"),
            ("Досуг", "/rubric/lifestyle/leisure", ""),
            ("Культура", "/rubric/lifestyle/culture", ""),
            ("Люкс", "/rubric/lifestyle/luxury", ""),
            ("Интервью", "/rubric/lifestyle/interview", ""),
            ("Линии жизни", "/rubric/lifestyle/lifeline", "")
        };
    }
}
