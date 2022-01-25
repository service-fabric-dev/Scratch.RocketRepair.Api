module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      backgroundImage: {
        'rocket-splash': "url('../public/rocket-splash.jpg')",
        'rocket-splash-short': "url('../public/rocket-splash-short.jpg')"
      },
      height: {
        '1/10': '10%',
        '1/20': '5%',
        '100vh': '100vh'
      }
    },
  },
  plugins: [],
}
