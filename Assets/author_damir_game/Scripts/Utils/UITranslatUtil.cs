

public static class UITranslatUtil
{
    public static string[] UI_RU =
    {
        "Продолжить", "Начать сначала", "Достижения", "Контакты", "Выход",
        "Вы точно хотите выйти из игры?", "Да", "Нет", "Вы точно хотите начать сначала?",
        "Следующая глава", "Меню"
    };

    public static string[] UI_EN =
    {
        "Continue", "Start over", "Achievements", "Contacts", "Exit",
        "Are you sure you want to exit the game?", "Yes", "No", "Are you sure you want to start over?",
        "Next chapter", "Menu"
    };

    public static string GetUIString(int id)
    {
        return LanguageUtil.IsRussian() ? UI_RU[id] : UI_EN[id];
    }
}
