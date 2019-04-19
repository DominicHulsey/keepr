<template>
  <vue-custom-scrollbar :settings="settings" class="scroll-area vaultHome sideVault">
    <div v-if="!this.loggedIn">
      <p class="mt-4" style="font-weight:bold">To view your vaults, you need to be logged in! Click <button
          type="button" class="btn btn-outline-info" data-target="#MyModal" data-toggle="modal">
          Here</button> to login.</p>
    </div>
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
      },
      loggedIn() {
        return this.$store.state.user.id
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
    background-color: #60a7f4;
  }
</style>