
namespace hoshi_lib.Input {
    public enum Key {
        // 摘要: 
        //     沒有按下任何鍵。
        None = 0,
        //
        // 摘要: 
        //     Cancel 鍵。
        Cancel = 1,
        //
        // 摘要: 
        //     Backspace 鍵。
        Back = 2,
        //
        // 摘要: 
        //     Tab 鍵。
        Tab = 3,
        //
        // 摘要: 
        //     Linefeed 鍵。
        LineFeed = 4,
        //
        // 摘要: 
        //     Clear 鍵。
        Clear = 5,
        //
        // 摘要: 
        //     Return 鍵。
        Return = 6,
        //
        // 摘要: 
        //     Enter 鍵。
        Enter = 6,
        //
        // 摘要: 
        //     Pause 鍵。
        Pause = 7,
        //
        // 摘要: 
        //     Caps Lock 鍵。
        CapsLock = 8,
        //
        // 摘要: 
        //     Caps Lock 鍵。
        Capital = 8,
        //
        // 摘要: 
        //     IME 韓文模式鍵。
        HangulMode = 9,
        //
        // 摘要: 
        //     IME 假名模式鍵。
        KanaMode = 9,
        //
        // 摘要: 
        //     IME Junja 模式鍵。
        JunjaMode = 10,
        //
        // 摘要: 
        //     IME 最終模式鍵。
        FinalMode = 11,
        //
        // 摘要: 
        //     IME 漢字 (日文) 模式鍵。
        KanjiMode = 12,
        //
        // 摘要: 
        //     IME 漢字 (韓文) 模式鍵。
        HanjaMode = 12,
        //
        // 摘要: 
        //     ESC 鍵。
        Escape = 13,
        //
        // 摘要: 
        //     IME 轉換鍵。
        ImeConvert = 14,
        //
        // 摘要: 
        //     IME 不轉換鍵。
        ImeNonConvert = 15,
        //
        // 摘要: 
        //     IME 接受鍵。
        ImeAccept = 16,
        //
        // 摘要: 
        //     IME 模式變更要求。
        ImeModeChange = 17,
        //
        // 摘要: 
        //     Spacebar 鍵。
        Space = 18,
        //
        // 摘要: 
        //     Page Up 鍵。
        PageUp = 19,
        //
        // 摘要: 
        //     Page Up 鍵。
        Prior = 19,
        //
        // 摘要: 
        //     Page Down 鍵。
        PageDown = 20,
        //
        // 摘要: 
        //     Page Down 鍵。
        Next = 20,
        //
        // 摘要: 
        //     End 鍵。
        End = 21,
        //
        // 摘要: 
        //     Home 鍵。
        Home = 22,
        //
        // 摘要: 
        //     向左鍵。
        Left = 23,
        //
        // 摘要: 
        //     向上鍵。
        Up = 24,
        //
        // 摘要: 
        //     向右鍵。
        Right = 25,
        //
        // 摘要: 
        //     向下鍵。
        Down = 26,
        //
        // 摘要: 
        //     Select 鍵。
        Select = 27,
        //
        // 摘要: 
        //     Print 鍵。
        Print = 28,
        //
        // 摘要: 
        //     Execute 鍵。
        Execute = 29,
        //
        // 摘要: 
        //     Print Screen 鍵。
        Snapshot = 30,
        //
        // 摘要: 
        //     Print Screen 鍵。
        PrintScreen = 30,
        //
        // 摘要: 
        //     Insert 鍵。
        Insert = 31,
        //
        // 摘要: 
        //     Delete 鍵。
        Delete = 32,
        //
        // 摘要: 
        //     Help 鍵。
        Help = 33,
        //
        // 摘要: 
        //     0 (零) 鍵。
        D0 = 34,
        //
        // 摘要: 
        //     1 (壹) 鍵。
        D1 = 35,
        //
        // 摘要: 
        //     2 鍵。
        D2 = 36,
        //
        // 摘要: 
        //     3 鍵。
        D3 = 37,
        //
        // 摘要: 
        //     4 鍵。
        D4 = 38,
        //
        // 摘要: 
        //     5 鍵。
        D5 = 39,
        //
        // 摘要: 
        //     6 鍵。
        D6 = 40,
        //
        // 摘要: 
        //     7 鍵。
        D7 = 41,
        //
        // 摘要: 
        //     8 鍵。
        D8 = 42,
        //
        // 摘要: 
        //     9 鍵。
        D9 = 43,
        //
        // 摘要: 
        //     A 鍵。
        A = 44,
        //
        // 摘要: 
        //     B 鍵。
        B = 45,
        //
        // 摘要: 
        //     C 鍵。
        C = 46,
        //
        // 摘要: 
        //     D 鍵。
        D = 47,
        //
        // 摘要: 
        //     E 鍵。
        E = 48,
        //
        // 摘要: 
        //     F 鍵。
        F = 49,
        //
        // 摘要: 
        //     G 鍵。
        G = 50,
        //
        // 摘要: 
        //     H 鍵。
        H = 51,
        //
        // 摘要: 
        //     I 鍵。
        I = 52,
        //
        // 摘要: 
        //     J 鍵。
        J = 53,
        //
        // 摘要: 
        //     K 鍵。
        K = 54,
        //
        // 摘要: 
        //     L 鍵。
        L = 55,
        //
        // 摘要: 
        //     M 鍵。
        M = 56,
        //
        // 摘要: 
        //     N 鍵。
        N = 57,
        //
        // 摘要: 
        //     O 鍵。
        O = 58,
        //
        // 摘要: 
        //     P 鍵。
        P = 59,
        //
        // 摘要: 
        //     Q 鍵。
        Q = 60,
        //
        // 摘要: 
        //     R 鍵。
        R = 61,
        //
        // 摘要: 
        //     S 鍵。
        S = 62,
        //
        // 摘要: 
        //     T 鍵。
        T = 63,
        //
        // 摘要: 
        //     U 鍵。
        U = 64,
        //
        // 摘要: 
        //     V 鍵。
        V = 65,
        //
        // 摘要: 
        //     W 鍵。
        W = 66,
        //
        // 摘要: 
        //     X 鍵。
        X = 67,
        //
        // 摘要: 
        //     Y 鍵。
        Y = 68,
        //
        // 摘要: 
        //     Z 鍵。
        Z = 69,
        //
        // 摘要: 
        //     左 Windows 標誌鍵 (Microsoft Natural Keyboard)。
        LWin = 70,
        //
        // 摘要: 
        //     右 Windows 標誌鍵 (Microsoft Natural Keyboard)。
        RWin = 71,
        //
        // 摘要: 
        //     應用程式鍵 (Microsoft Natural Keyboard)。
        Apps = 72,
        //
        // 摘要: 
        //     電腦休眠鍵。
        Sleep = 73,
        //
        // 摘要: 
        //     數字鍵台上的 0 鍵。
        NumPad0 = 74,
        //
        // 摘要: 
        //     數字鍵台上的 1 鍵。
        NumPad1 = 75,
        //
        // 摘要: 
        //     數字鍵台上的 2 鍵。
        NumPad2 = 76,
        //
        // 摘要: 
        //     數字鍵台上的 3 鍵。
        NumPad3 = 77,
        //
        // 摘要: 
        //     數字鍵台上的 4 鍵。
        NumPad4 = 78,
        //
        // 摘要: 
        //     數字鍵台上的 5 鍵。
        NumPad5 = 79,
        //
        // 摘要: 
        //     數字鍵台上的 6 鍵。
        NumPad6 = 80,
        //
        // 摘要: 
        //     數字鍵台上的 7 鍵。
        NumPad7 = 81,
        //
        // 摘要: 
        //     數字鍵台上的 8 鍵。
        NumPad8 = 82,
        //
        // 摘要: 
        //     數字鍵台上的 9 鍵。
        NumPad9 = 83,
        //
        // 摘要: 
        //     Multiply 鍵。
        Multiply = 84,
        //
        // 摘要: 
        //     加號鍵。
        Add = 85,
        //
        // 摘要: 
        //     Separator 鍵。
        Separator = 86,
        //
        // 摘要: 
        //     Subtract 鍵。
        Subtract = 87,
        //
        // 摘要: 
        //     Decimal 鍵。
        Decimal = 88,
        //
        // 摘要: 
        //     Divide 鍵。
        Divide = 89,
        //
        // 摘要: 
        //     F1 鍵。
        F1 = 90,
        //
        // 摘要: 
        //     F2 鍵。
        F2 = 91,
        //
        // 摘要: 
        //     F3 鍵。
        F3 = 92,
        //
        // 摘要: 
        //     F4 鍵。
        F4 = 93,
        //
        // 摘要: 
        //     F5 鍵。
        F5 = 94,
        //
        // 摘要: 
        //     F6 鍵。
        F6 = 95,
        //
        // 摘要: 
        //     F7 鍵。
        F7 = 96,
        //
        // 摘要: 
        //     F8 鍵。
        F8 = 97,
        //
        // 摘要: 
        //     F9 鍵。
        F9 = 98,
        //
        // 摘要: 
        //     F10 鍵。
        F10 = 99,
        //
        // 摘要: 
        //     F11 鍵。
        F11 = 100,
        //
        // 摘要: 
        //     F12 鍵。
        F12 = 101,
        //
        // 摘要: 
        //     F13 鍵。
        F13 = 102,
        //
        // 摘要: 
        //     F14 鍵。
        F14 = 103,
        //
        // 摘要: 
        //     F15 鍵。
        F15 = 104,
        //
        // 摘要: 
        //     F16 鍵。
        F16 = 105,
        //
        // 摘要: 
        //     F17 鍵。
        F17 = 106,
        //
        // 摘要: 
        //     F18 鍵。
        F18 = 107,
        //
        // 摘要: 
        //     F19 鍵。
        F19 = 108,
        //
        // 摘要: 
        //     F20 鍵。
        F20 = 109,
        //
        // 摘要: 
        //     F21 鍵。
        F21 = 110,
        //
        // 摘要: 
        //     F22 鍵。
        F22 = 111,
        //
        // 摘要: 
        //     F23 鍵。
        F23 = 112,
        //
        // 摘要: 
        //     F24 鍵。
        F24 = 113,
        //
        // 摘要: 
        //     Num Lock 鍵。
        NumLock = 114,
        //
        // 摘要: 
        //     Scroll Lock 鍵。
        Scroll = 115,
        //
        // 摘要: 
        //     左 Shift 鍵。
        LeftShift = 116,
        //
        // 摘要: 
        //     右 Shift 鍵。
        RightShift = 117,
        //
        // 摘要: 
        //     左 CTRL 鍵。
        LeftCtrl = 118,
        //
        // 摘要: 
        //     右 CTRL 鍵。
        RightCtrl = 119,
        //
        // 摘要: 
        //     左 ALT 鍵。
        LeftAlt = 120,
        //
        // 摘要: 
        //     右 ALT 鍵。
        RightAlt = 121,
        //
        // 摘要: 
        //     瀏覽器上一頁鍵。
        BrowserBack = 122,
        //
        // 摘要: 
        //     瀏覽器下一頁鍵。
        BrowserForward = 123,
        //
        // 摘要: 
        //     瀏覽器重新整理鍵。
        BrowserRefresh = 124,
        //
        // 摘要: 
        //     瀏覽器停止鍵。
        BrowserStop = 125,
        //
        // 摘要: 
        //     瀏覽器搜尋鍵。
        BrowserSearch = 126,
        //
        // 摘要: 
        //     瀏覽器我的最愛鍵。
        BrowserFavorites = 127,
        //
        // 摘要: 
        //     瀏覽器首頁鍵。
        BrowserHome = 128,
        //
        // 摘要: 
        //     音量靜音鍵。
        VolumeMute = 129,
        //
        // 摘要: 
        //     音量降低鍵。
        VolumeDown = 130,
        //
        // 摘要: 
        //     音量提高鍵。
        VolumeUp = 131,
        //
        // 摘要: 
        //     媒體下一首鍵。
        MediaNextTrack = 132,
        //
        // 摘要: 
        //     媒體上一首鍵。
        MediaPreviousTrack = 133,
        //
        // 摘要: 
        //     媒體停止鍵。
        MediaStop = 134,
        //
        // 摘要: 
        //     媒體播放暫停鍵。
        MediaPlayPause = 135,
        //
        // 摘要: 
        //     啟動郵件鍵。
        LaunchMail = 136,
        //
        // 摘要: 
        //     選取媒體鍵。
        SelectMedia = 137,
        //
        // 摘要: 
        //     啟動 Application1 鍵。
        LaunchApplication1 = 138,
        //
        // 摘要: 
        //     啟動 Application2 鍵。
        LaunchApplication2 = 139,
        //
        // 摘要: 
        //     OEM 分號鍵。
        OemSemicolon = 140,
        //
        // 摘要: 
        //     OEM 1 鍵。
        Oem1 = 140,
        //
        // 摘要: 
        //     OEM 加號鍵。
        OemPlus = 141,
        //
        // 摘要: 
        //     OEM 逗號鍵。
        OemComma = 142,
        //
        // 摘要: 
        //     OEM 減號鍵。
        OemMinus = 143,
        //
        // 摘要: 
        //     OEM 句號鍵。
        OemPeriod = 144,
        //
        // 摘要: 
        //     OEM 問號鍵。
        OemQuestion = 145,
        //
        // 摘要: 
        //     OEM 2 鍵。
        Oem2 = 145,
        //
        // 摘要: 
        //     OEM 波狀符號鍵。
        OemTilde = 146,
        //
        // 摘要: 
        //     OEM 3 鍵。
        Oem3 = 146,
        //
        // 摘要: 
        //     ABNT_C1 (巴西) 鍵。
        AbntC1 = 147,
        //
        // 摘要: 
        //     ABNT_C2 (巴西) 鍵。
        AbntC2 = 148,
        //
        // 摘要: 
        //     OEM 左括弧鍵。
        OemOpenBrackets = 149,
        //
        // 摘要: 
        //     OEM 4 鍵。
        Oem4 = 149,
        //
        // 摘要: 
        //     OEM 管道鍵。
        OemPipe = 150,
        //
        // 摘要: 
        //     OEM 5 鍵。
        Oem5 = 150,
        //
        // 摘要: 
        //     OEM 右括弧鍵。
        OemCloseBrackets = 151,
        //
        // 摘要: 
        //     OEM 6 鍵。
        Oem6 = 151,
        //
        // 摘要: 
        //     OEM 引號鍵。
        OemQuotes = 152,
        //
        // 摘要: 
        //     OEM 7 鍵。
        Oem7 = 152,
        //
        // 摘要: 
        //     OEM 8 鍵。
        Oem8 = 153,
        //
        // 摘要: 
        //     OEM 反斜線鍵。
        OemBackslash = 154,
        //
        // 摘要: 
        //     OEM 102 鍵。
        Oem102 = 154,
        //
        // 摘要: 
        //     遮罩由 IME 處理之實際鍵的特殊鍵。
        ImeProcessed = 155,
        //
        // 摘要: 
        //     遮罩做為系統鍵處理之實際鍵的特殊鍵。
        System = 156,
        //
        // 摘要: 
        //     OEM ATTN 鍵。
        OemAttn = 157,
        //
        // 摘要: 
        //     DBE_ALPHANUMERIC 鍵。
        DbeAlphanumeric = 157,
        //
        // 摘要: 
        //     OEM FINISH 鍵。
        OemFinish = 158,
        //
        // 摘要: 
        //     DBE_KATAKANA 鍵。
        DbeKatakana = 158,
        //
        // 摘要: 
        //     DBE_HIRAGANA 鍵。
        DbeHiragana = 159,
        //
        // 摘要: 
        //     OEM COPY 鍵。
        OemCopy = 159,
        //
        // 摘要: 
        //     DBE_SBCSCHAR 鍵。
        DbeSbcsChar = 160,
        //
        // 摘要: 
        //     OEM AUTO 鍵。
        OemAuto = 160,
        //
        // 摘要: 
        //     DBE_DBCSCHAR 鍵。
        DbeDbcsChar = 161,
        //
        // 摘要: 
        //     OEM ENLW 鍵。
        OemEnlw = 161,
        //
        // 摘要: 
        //     OEM BACKTAB 鍵。
        OemBackTab = 162,
        //
        // 摘要: 
        //     DBE_ROMAN 鍵。
        DbeRoman = 162,
        //
        // 摘要: 
        //     DBE_NOROMAN 鍵。
        DbeNoRoman = 163,
        //
        // 摘要: 
        //     ATTN 鍵。
        Attn = 163,
        //
        // 摘要: 
        //     CRSEL 鍵。
        CrSel = 164,
        //
        // 摘要: 
        //     DBE_ENTERWORDREGISTERMODE 鍵。
        DbeEnterWordRegisterMode = 164,
        //
        // 摘要: 
        //     EXSEL 鍵。
        ExSel = 165,
        //
        // 摘要: 
        //     DBE_ENTERIMECONFIGMODE 鍵。
        DbeEnterImeConfigureMode = 165,
        //
        // 摘要: 
        //     ERASE EOF 鍵。
        EraseEof = 166,
        //
        // 摘要: 
        //     DBE_FLUSHSTRING 鍵。
        DbeFlushString = 166,
        //
        // 摘要: 
        //     PLAY 鍵。
        Play = 167,
        //
        // 摘要: 
        //     DBE_CODEINPUT 鍵。
        DbeCodeInput = 167,
        //
        // 摘要: 
        //     DBE_NOCODEINPUT 鍵。
        DbeNoCodeInput = 168,
        //
        // 摘要: 
        //     ZOOM 鍵。
        Zoom = 168,
        //
        // 摘要: 
        //     保留常數供日後使用。
        NoName = 169,
        //
        // 摘要: 
        //     DBE_DETERMINESTRING 鍵。
        DbeDetermineString = 169,
        //
        // 摘要: 
        //     DBE_ENTERDLGCONVERSIONMODE 鍵。
        DbeEnterDialogConversionMode = 170,
        //
        // 摘要: 
        //     PA1 鍵。
        Pa1 = 170,
        //
        // 摘要: 
        //     OEM Clear 鍵。
        OemClear = 171,
        //
        // 摘要: 
        //     這個按鍵是與其他按鍵搭配使用，以建立單一組合字元。
        DeadCharProcessed = 172
    }
}
