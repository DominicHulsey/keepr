<template>
  <vue-custom-scrollbar :settings="settings" class="scroll-area text-white vaultHome sideVault mx-2">
    <div v-if="!this.loggedIn">
      <p class="mt-4" style="font-weight:bold">To view your vaults, you need to be logged in! Click <button
          type="button" class="btn bgPurp bordR" data-target="#MyModal" data-toggle="modal">
          Here</button> to login.</p>
    </div>
    <div class="d-flex flex-row flex-nowrap row" style="height:20vh;">
      <vault-temp-mobile v-for="vault in vaults" :vault="vault">
      </vault-temp-mobile>
    </div>
  </vue-custom-scrollbar>
</template>

<script>
  import VaultTempMobile from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultTempMobile.vue"
  import vueCustomScrollbar from 'vue-custom-scrollbar'
  export default {
    name: 'vaultHome',
    data() {
      return {
        settings: {
          suppressScrollY: true,
          wheelPropagation: false,
          // maxScrollbarLength: 300,
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
      VaultTempMobile,
      vueCustomScrollbar,
    }
  }
</script>


<style scoped>
  .sideVault {
    position: sticky !important;
    height: 20vh;
  }

  .makeVault {
    cursor: pointer;
  }

  .scroll-area {
    position: relative;
    width: auto;
    height: 20vh;
    background-color: #343a40;
  }
</style>