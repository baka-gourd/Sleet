const environment = require('./src/environments/environment.js').environment;
module.exports = {
  purge: {
    enabled: environment.production,
    content: [
      './src/**/*.{html,ts}',
    ]
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
