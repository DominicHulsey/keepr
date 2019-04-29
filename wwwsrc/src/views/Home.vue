<template>
  <div class="home container-fluid backgroundMain h-100">
    <login-modal></login-modal>
    <keep-form></keep-form>
    <vault-form></vault-form>
    <div v-if="$mq == 'lg'" class="row mt-4">
      <div class="col-9 p-0">
        <keep-template></keep-template>
      </div>
      <div class="d-flex p-2 bgB float-right rounded vaultTitle float-right col-3 widthSet">
        <div class="col-12 vaultTitle bg-black card bg-dark justify-content-center">
          <h4 class="vaultTitle text-white mt-3">
            Vaults:
            <i v-if="!this.loggedIn" class="fas fa-plus-square makeVault add" @click="login()"></i>
            <i v-else class="fas fa-plus-square makeVault add" data-toggle="modal" data-target="#exampleModal2"></i>
          </h4>
          <vault-home></vault-home>
        </div>
      </div>
      <!-- add vaults here -->
    </div>
    <div v-else-if="$mq == 'md'" class="row mx-1 mt-4">
      <div style="z-index:1" class="col-12 vaultTitleSM bg-black bg-dark justify-content-center">
        <!-- <i v-if="!this.loggedIn" class="fas fa-plus-square makeVault add" @click="login()"></i> -->
        <!-- <i v-else class="fas fa-plus-square makeVault add" data-toggle="modal" data-target="#exampleModal2"></i> -->
        <vault-mobile></vault-mobile>
      </div>
      <div class="col-9 p-0">
        <keep-template></keep-template>
      </div>
    </div>

    <!-- add vaults here -->
  </div>
  </div>
</template>

<script>
  import KeepTemplate from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepTemplate.vue";
  import KeepForm from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepForm.vue";
  import VaultForm from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultForm.vue";
  import VaultHome from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultHome.vue";
  import VaultMobile from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultMobile.vue";

  import LoginModal from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/loginModal.vue"
  import { Drag, Drop } from "vue-drag-drop";
  export default {
    name: "home",
    props: ["keep"],
    async mounted() {
      await this.$store.dispatch("getKeeps");
      // await this.$store.dispatch("numToDraw", this.$store.state.keeps.length);
      await this.$store.dispatch("authenticate");
      await this.$store.dispatch("getVaults");
    },
    data() {
      return {
      }
    },
    computed: {
      imageIndexes() {
        return this.$store.state.indexToDraw
      },
      loggedIn() {
        return this.$store.state.user.id
      }
      // checkAutho() {
      //   if (!this.$store.state.user.id) {
      //     this.loggedIn = false;
      //   }
      //   else {
      //     $('#MyModal').modal('hide');
      //   }
      // }
    },
    components: {
      KeepForm,
      KeepTemplate,
      VaultHome,
      Drag,
      Drop,
      VaultForm,
      LoginModal,
      VaultMobile
    },
    methods: {
      addToVault(keep) {
        console.log("nothing");
      },
      login() {
        $('#MyModal').modal('show');
      },
      // if (!this.$store.state.user.id) {
      //   $('#MyModal').modal('toggle');
      //   $('#MyModal').modal('show');
      // else {
      //   $('#MyModal').modal('hide');
      // }
      remFromVault(keep) {
        this.$store.dispatch('delete')
      }
    },
  }
</script>

<style scoped>
  .widthSet {
    width: 300px;
  }

  .vaultTitle {
    position: sticky !important;
    top: 15vh;
    max-height: 85vh
  }

  .vaultTitleSM {
    position: sticky !important;
    top: 13vh;
  }

  .backgroundMain {
    background-color: transparent;
  }

  .bgBlack {
    background-color: black;
  }

  .bg-colored {
    background-color: #9854bb;
  }

  .add {
    cursor: pointer;
  }
</style>
<style>
</style>