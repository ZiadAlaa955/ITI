import i18n from "i18next";
import { initReactI18next } from "react-i18next";

const resources = {
  en: {
    translation: {
      nav: {
        logo: "Tech News",
        home: "Home",
        latest: "Latest News",
        add: "Add Post",
        login: "Log in",
        signup: "Sign up",
      },
      home: {
        welcome: "Welcome",
        subtitle: "Catch up on the latest breakthroughs in technology.",
      },
      theme: { light: "Light", dark: "Dark" },
      lang: { toggle: "عربي 🌐" },
      addPost: {
        title: "Submit News",
        headlineLabel: "Headline",
        headlinePlaceholder: "Enter article headline",
        publisherLabel: "Publisher Name",
        publisherPlaceholder: "e.g., Julian Vossen",
        categoryLabel: "Category",
        categoryPlaceholder: "e.g., AI, Hardware...",
        imageLabel: "Image URL",
        imagePlaceholder: "Enter Your Image Url",
        descLabel: "Short Description (Card Intro)",
        descPlaceholder: "Brief description for the news card...",
        contentLabel: "Full Article Content",
        contentPlaceholder: "Write the full article details here...",
        submitBtn: "Publish News",
      },
      search: { placeholder: "Search news with category..." },
      card: { showDetails: "Show Details" },
      loginAuth: {
        title: "Tech News",
        subtitle: "Sign in to access premium intelligence.",
        emailPlaceholder: "Email Address",
        passwordPlaceholder: "Password",
        btn: "Sign In",
        prompt: "Don't have an account?",
        link: "Sign up",
        success: "Welcome back",
        invalid: "Invalid email or password. Please try again.",
        error: "Could not connect to the server.",
      },
      signupAuth: {
        title: "Signup",
        subtitle: "Create your account to access premium intelligence.",
        namePlaceholder: "Full Name",
        emailPlaceholder: "Email Address",
        passwordPlaceholder: "Password",
        confirmPlaceholder: "Confirm Password",
        btn: "Create Account",
        prompt: "Already have an account?",
        link: "Log in",
        matchError: "Passwords do not match!",
        success: "Account created successfully!",
        error: "Failed to create account. Please try again.",
      },
    },
  },
  ar: {
    translation: {
      nav: {
        logo: "أخبار التقنية",
        home: "الرئيسية",
        latest: "أحدث الأخبار",
        add: "إضافة مقال",
        login: "تسجيل الدخول",
        signup: "إنشاء حساب",
      },
      home: {
        welcome: "مرحباً",
        subtitle: "تابع أحدث التطورات والاكتشافات في عالم التكنولوجيا.",
      },
      theme: { light: "مضيء", dark: "داكن" },
      lang: { toggle: "English 🌐" },
      addPost: {
        title: "إضافة خبر",
        headlineLabel: "العنوان الرئيسي",
        headlinePlaceholder: "أدخل عنوان المقال",
        publisherLabel: "اسم الناشر",
        publisherPlaceholder: "مثال: أحمد محمد",
        categoryLabel: "الفئة",
        categoryPlaceholder: "مثال: ذكاء اصطناعي، أجهزة...",
        imageLabel: "رابط الصورة",
        imagePlaceholder: "أدخل رابط الصورة الخاص بك",
        descLabel: "وصف قصير (مقدمة البطاقة)",
        descPlaceholder: "وصف موجز لبطاقة الخبر...",
        contentLabel: "محتوى المقال بالكامل",
        contentPlaceholder: "اكتب تفاصيل المقال الكاملة هنا...",
        submitBtn: "نشر الخبر",
      },
      search: { placeholder: "البحث في الأخبار حسب الفئة..." },
      card: { showDetails: "عرض التفاصيل" },
      loginAuth: {
        title: "أخبار التقنية",
        subtitle: "سجل الدخول للوصول إلى المحتوى المتميز.",
        emailPlaceholder: "البريد الإلكتروني",
        passwordPlaceholder: "كلمة المرور",
        btn: "تسجيل الدخول",
        prompt: "ليس لديك حساب؟",
        link: "إنشاء حساب",
        success: "مرحباً بعودتك",
        invalid:
          "البريد الإلكتروني أو كلمة المرور غير صحيحة. يرجى المحاولة مرة أخرى.",
        error: "تعذر الاتصال بالخادم.",
      },
      signupAuth: {
        title: "إنشاء حساب",
        subtitle: "أنشئ حسابك للوصول إلى المحتوى المتميز.",
        namePlaceholder: "الاسم الكامل",
        emailPlaceholder: "البريد الإلكتروني",
        passwordPlaceholder: "كلمة المرور",
        confirmPlaceholder: "تأكيد كلمة المرور",
        btn: "إنشاء الحساب",
        prompt: "لديك حساب بالفعل؟",
        link: "تسجيل الدخول",
        matchError: "كلمات المرور غير متطابقة!",
        success: "تم إنشاء الحساب بنجاح!",
        error: "فشل في إنشاء الحساب. يرجى المحاولة مرة أخرى.",
      },
    },
  },
};

const savedLanguage = localStorage.getItem("app-lang") || "en";

document.documentElement.dir = savedLanguage === "ar" ? "rtl" : "ltr";
document.documentElement.lang = savedLanguage;

i18n.use(initReactI18next).init({
  resources,
  lng: savedLanguage,
  fallbackLng: "en",
  interpolation: { escapeValue: false },
});

export default i18n;
