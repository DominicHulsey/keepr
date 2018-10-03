<template>
  <div class="hello">
    {{burgers}}
  </div>
</template>

<script>
  export default {
    name: 'HelloWorld',
    computed: {
      burgers() {
        return this.$store.state.burgers
      }
    },
    mounted() {
      this.$store.dispatch('getAllBurgers')
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h3 {
    margin: 40px 0 0;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>