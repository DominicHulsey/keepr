<template>
  <div class="backgroundBro" id="app">
    <navbar class="sticky-top"></navbar>
    <router-view />
  </div>
</template>


<script>
  import Navbar from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/Navbar.vue"
  export default {
    name: "app",
    components: {
      Navbar
    }
  }
</script>

<style>
  #app {
    font-family: 'Montserrat', sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  body {
    background-color: #eaebeb;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  .backgroundBro {
    background-color: #f4f4f4;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>