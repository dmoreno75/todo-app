/** @type {import('tailwindcss').Config} */ 

const defaultTheme = require('tailwindcss/defaultTheme')

module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {},
    colors: {
      ...defaultTheme.colors,
      blue: {
        primary: '#0E1D50',
        background: '#D8DCE9'
      },
      white:  '#FFFFFF',
      red: '#b91c1c'
    }
  },
  variants: {
    extend: {},
  },
  plugins: [],
}