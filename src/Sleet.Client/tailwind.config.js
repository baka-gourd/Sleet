module.exports = {
    purge: [
        "./*.{js,ts,jsx,tsx,vue}",
        "./**/*.{js,ts,jsx,tsx,vue}",
        "./**/**/*.{js,ts,tsx,jsx,vue}",
    ],
    darkMode: false, // or 'media' or 'class'
    theme: {
        extend: {},
    },
    variants: {
        extend: {},
    },
    plugins: [],
};
