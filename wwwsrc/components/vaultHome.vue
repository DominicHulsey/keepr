<template>
  <vue-custom-scrollbar :settings="settings" class="scroll-area vaultHome sideVault">
    <vault-template v-for="vault in vaults" :vault="vault"></vault-template>
  </vue-custom-scrollbar>
</template>

<script>
  import VaultTemplate from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultTemplate.vue"
  import vueCustomScrollbar from 'vue-custom-scrollbar'
  export default {
    name: 'vaultHome',
    data() {
      return {
        settings: {
          maxScrollbarLength: 300,
        }
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    components: {
      VaultTemplate,
      vueCustomScrollbar,
    }
  }
</script>


<style scoped>
  .sideVault {
    position: sticky !important;
    top: 5vh;
    height: 80vh;
  }

  .makeVault {
    cursor: pointer;
  }

  .scroll-area {
    position: relative;
    width: auto;
    height: 75vh;
  }
</style>