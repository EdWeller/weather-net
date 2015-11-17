using System.ComponentModel;

namespace WeatherNet.Model
{
    /// <summary>
    /// Accepted languages
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// The english 
        /// </summary>
        [Description("en")]
        English,

        /// <summary>
        /// The russian
        /// </summary>
        [Description("ru")]
        Russian,

        /// <summary>
        /// The italian
        /// </summary>
        [Description("it")]
        Italian,

        /// <summary>
        /// The spanish
        /// </summary>
        [Description("sp")]
        Spanish,

        /// <summary>
        /// The ukrainian
        /// </summary>
        [Description("ua")]
        Ukrainian,

        /// <summary>
        /// The german
        /// </summary>
        [Description("de")]
        German,

        /// <summary>
        /// The portuguese
        /// </summary>
        [Description("pt")]
        Portuguese,

        /// <summary>
        /// The romanian
        /// </summary>
        [Description("ro")]
        Romanian,

        /// <summary>
        /// The polish
        /// </summary>
        [Description("pl")]
        Polish,

        /// <summary>
        /// The finnish
        /// </summary>
        [Description("fi")]
        Finnish,

        /// <summary>
        /// The dutch
        /// </summary>
        [Description("nl")]
        Dutch,

        /// <summary>
        /// The french
        /// </summary>
        [Description("fr")]
        French,

        /// <summary>
        /// The bulgarian
        /// </summary>
        [Description("bg")]
        Bulgarian,

        /// <summary>
        /// The swedish
        /// </summary>
        [Description("se")]
        Swedish,

        /// <summary>
        /// The chinese traditional
        /// </summary>
        [Description("zh_tw")]
        ChineseTraditional,

        /// <summary>
        /// The chinese simplified
        /// </summary>
        [Description("zh_cn")]
        ChineseSimplified,

        /// <summary>
        /// The turkish
        /// </summary>
        [Description("tr")]
        Turkish,

        /// <summary>
        /// The czech
        /// </summary>
        [Description("cz")]
        Czech,

        /// <summary>
        /// The galician
        /// </summary>
        [Description("gl")]
        Galician,

        /// <summary>
        /// The vietnamese
        /// </summary>
        [Description("vi")]
        Vietnamese,

        /// <summary>
        /// The arabic
        /// </summary>
        [Description("ar")]
        Arabic,

        /// <summary>
        /// The macedonian
        /// </summary>
        [Description("mk")]
        Macedonian,

        /// <summary>
        /// The slovak
        /// </summary>
        [Description("sk")]
        Slovak

    }

    /// <summary>
    /// Measurement systems
    /// </summary>
    public enum Units
    {
        /// <summary>
        /// The metric system.
        /// </summary>
        [Description("metric")]
        Metric,

        /// <summary>
        /// The imperial system.
        /// </summary>
        [Description("imperial")]
        Imperial
    }
}