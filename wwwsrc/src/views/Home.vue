<template>
  <div class="home container-fluid backgroundMain h-100">
    <h1 class="text-white">Welcome to Keepr™</h1>
    <keep-form></keep-form>
    <vault-form></vault-form>
    <div class="row">
      <div :class="$mq | mq({xxs: 'col-12', xs: 'col-12', sm: 'col-12', md: 'col-10', lg: 'col-10'})">
        <keep-template :keeps="keeps"></keep-template>
        <!-- <div class="row justify-content-center mt-1" v-if="keeps.length > 0">
        </div> -->
      </div>
      <div v-if="$mq == 'md' || $mq == 'lg'" class="d-flex p-2 vaultTitle col-2 mt-2 flex-column ">
        <div v-if="$mq == 'md' || $mq == 'lg'" class="col-12 vaultTitle card bg-colored">
          <h4 class="vaultTitle mt-3">
            Vaults:
            <i class="fas fa-plus-square makeVault add" data-toggle="modal" data-target="#exampleModal2"></i>
          </h4>

          <vault-home></vault-home>
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
  import { Drag, Drop } from "vue-drag-drop";
  export default {
    name: "home",
    props: ["keep"],
    async mounted() {
      await this.$store.dispatch("getKeeps");
      await this.$store.dispatch("numToDraw", this.$store.state.keeps.length);
      await this.$store.dispatch("getVaults");
      // this.addImages();
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    computed: {
      imageIndexes() {
        return this.$store.state.indexToDraw
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    components: {
      KeepForm,
      KeepTemplate,
      VaultHome,
      Drag,
      Drop,
      VaultForm,
    },
    methods: {
      addToVault(keep) {
        console.log("nothing");
      },
      runFunctionBro() {
        console.log("wow")
      }
    }
  };
</script>

<style scoped>
  .vaultTitle {
    position: sticky !important;
    top: 10vh;
    max-height: 85vh
  }

  .backgroundMain {
    background-color: transparent;
  }

  .bg-colored {
    background-color: antiquewhite;
    ;
  }

  .add {
    cursor: pointer;
  }
</style>
<style>
</style>