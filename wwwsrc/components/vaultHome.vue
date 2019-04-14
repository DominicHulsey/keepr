<template>
  <div class="vaultHome col-2 mt-4 border-left border-right d-flex flex-column sideVault">
    <div class="d-flex justify-content-around p-2">
      <h3>Vaults</h3>
      <i class="fas fa-plus-square fa-2x makeVault" data-toggle="modal" data-target="#exampleModal"></i>
    </div>
    <vault-template v-for="vault in vaults" :vault="vault"></vault-template>
  </div>
</template>

<script>
  import VaultTemplate from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultTemplate.vue"
  export default {
    name: 'vaultHome',
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }

    },
    methods: {
    },
    components: {
      VaultTemplate
    }
  }
</script>


<style scoped>
  .sideVault {
    position: sticky !important;
    top: 1vh;
    height: 100vh;
  }

  .makeVault {
    cursor: pointer;
  }
</style>