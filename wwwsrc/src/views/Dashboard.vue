<template>
  <div class="Dashboard">
    <div class="row mt-5 justify-content-center">
      <div class="col-8 px-0 mt-5 border h-100">
        <div class="bg-info text-white h-25 text-left pl-3">
          <h1>Dashboard</h1>
        </div>
        <div class="row justify-content-around">
          <h1 style="text-decoration:underline">Vaults:</h1>
          <div v-for="vault in vaults" class="col-2 my-5 border">
            <h3>{{vault.name}}</h3>
            <h3>{{vault.description}}</h3>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
  export default {
    name: 'Dashboard',
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>